import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { environment } from '../../../../environments/environment'
import UserDto from '../../DTOs/user/user.dto'
import PaginatedResponse from '../../DTOs/shared/paginated.response'
import UserFields from '../../DTOs/user/user-fields.dto'

@Injectable({
    providedIn: 'root',
})
export class UserService {
    private readonly apiUrl = `${environment.apiUrl}/users`

    constructor(private http: HttpClient) {}

    getUsers(request: any = {}) {
        return this.http.get<PaginatedResponse<UserDto>>(this.apiUrl, {
            params: request,
        })
    }

    getFields() {
        return this.http.get<UserFields>(`${this.apiUrl}/fields`)
    }

    create(request: any) {
        return this.http.post<void>(this.apiUrl, request)
    }

    updateRole(id: string, role: string) {
        return this.http.patch<void>(`${this.apiUrl}/${id}/role`, { role })
    }

    updateActive(id: string, isActive: boolean) {
        return this.http.patch<void>(`${this.apiUrl}/${id}/active`, { isActive })
    }
}
