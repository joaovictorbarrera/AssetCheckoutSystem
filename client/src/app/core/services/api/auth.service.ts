import { HttpClient } from '@angular/common/http'
import { Injectable, signal } from '@angular/core'
import { firstValueFrom } from 'rxjs'
import { environment } from '../../../../environments/environment'
import UserDto from '../../DTOs/user/user.dto'
import { Router } from '@angular/router'
import { Role } from '../../enums/role'
import { PageLoadingService } from '../util/page-loading.service'

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = `${environment.apiUrl}/Auth`

  readonly currentUser = signal<UserDto | null>(null)

  private loadUserPromise?: Promise<UserDto | null>

  private refreshTimeout?: number
  private refreshInProgress = false

  public get isManager() {
    return this.currentUser()?.role === Role.Admin || this.currentUser()?.role === Role.AssetManager
  }

  public get isAdmin() {
    return this.currentUser()?.role === Role.Admin
  }

  constructor(
    private http: HttpClient,
    private router: Router,
    private pageLoadingService: PageLoadingService
  ) {
    window.addEventListener('focus', () => this.onWindowFocus())
  }

  initializeAuth(): Promise<void> {
    const token = localStorage.getItem('authorizationToken')

    if (!token) {
      return Promise.resolve()
    }

    if (this.shouldRefresh(token)) {
      this.pageLoadingService.setLoading(true)
      return this.refreshToken()
    } else {
      this.scheduleRefresh(token)
      return Promise.resolve()
    }
  }

  async login(body: unknown): Promise<string | null> {
    try {
      const res = await firstValueFrom(
        this.http.post<{ authorizationToken: string }>(`${this.apiUrl}/login`, body, {
          withCredentials: true,
        }),
      )

      const authToken = res.authorizationToken

      localStorage.setItem('authorizationToken', authToken)

      this.scheduleRefresh(authToken)

      this.router.navigate(['/'])

      return null
    } catch (err: any) {
      if (err.status === 401) {
        return 'Error logging in with this email or password'
      }

      return 'Unknown error'
    }
  }

  private shouldRefresh(token: string): boolean {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]))
      const expiresAt = payload.exp * 1000

      return expiresAt <= Date.now() + 60_000
    } catch {
      return true;
    }
  }

  private scheduleRefresh(token: string) {
    if (this.refreshTimeout) {
      clearTimeout(this.refreshTimeout)
    }

    const payload = JSON.parse(atob(token.split('.')[1]))
    const expiresAt = payload.exp * 1000

    const delay = Math.max(expiresAt - Date.now() - 60_000, 0)

    this.refreshTimeout = window.setTimeout(() => {
      this.refreshToken()
    }, delay)
  }

  private onWindowFocus() {
    const token = localStorage.getItem('authorizationToken')

    if (!token) {
      return
    }

    if (this.shouldRefresh(token)) {
      this.refreshToken()
    }
  }

  refreshToken(): Promise<void> {
    if (this.refreshInProgress) {
      // wait for current refresh to finish
      return new Promise((resolve) => {
        const wait = () => {
          if (!this.refreshInProgress) resolve()
          else setTimeout(wait, 50)
        }
        wait()
      })
    }

    this.refreshInProgress = true

    return firstValueFrom(
      this.http.get<{ authorizationToken: string }>(`${this.apiUrl}/refresh`, {
        withCredentials: true,
      }),
    )
      .then((res) => {
        const authToken = res.authorizationToken
        localStorage.setItem('authorizationToken', authToken)
        this.scheduleRefresh(authToken)
      })
      .catch((err) => {
        console.log(err?.title ?? err)
        this.logout()
      })
      .finally(() => {
        this.refreshInProgress = false
        this.pageLoadingService.setLoading(false)
      })
  }

  logout() {
    if (this.refreshTimeout) {
      clearTimeout(this.refreshTimeout)
      this.refreshTimeout = undefined
    }

    localStorage.removeItem('authorizationToken')
    this.currentUser.set(null)
    this.router.navigate(['/login'])
  }

  async loadUser(): Promise<UserDto | null> {
    if (this.currentUser()) {
      return this.currentUser()
    }

    const token = localStorage.getItem('authorizationToken')
    if (!token?.trim()) {
      return null
    }

    if (this.loadUserPromise) {
      return this.loadUserPromise
    }

    this.loadUserPromise = firstValueFrom(this.http.get<UserDto>(`${this.apiUrl}/me`))
      .then((user) => {
        this.currentUser.set(user)
        return user
      })
      .catch(() => {
        this.logout()
        return null
      })
      .finally(() => {
        this.loadUserPromise = undefined
      })

    return this.loadUserPromise
  }

  resetPassword(request: any) {
    return this.http.post<void>(`${this.apiUrl}/reset-password`, request)
  }
}
