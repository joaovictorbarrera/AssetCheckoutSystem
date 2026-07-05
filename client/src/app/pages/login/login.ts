import { Component, signal } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { Router, RouterModule } from '@angular/router'
import { SubmitButton } from '../../core/components/submit-button/submit-button'
import { AuthService } from '../../core/services/api/auth.service'
@Component({
  selector: 'app-login',
  imports: [RouterModule, SubmitButton, FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  emailAddress = ''
  password = ''

  failMessage = signal<string | null>(null)
  loading = signal(false)

  constructor(
    public authService: AuthService,
    public router: Router,
  ) {}

  async login(event: any) {
    event.preventDefault()

    this.loading.set(true)
    const error = await this.authService.login({
      emailAddress: this.emailAddress,
      password: this.password,
    })

    this.loading.set(false)
    if (error) {
      this.failMessage.set(error)
    }
  }
}
