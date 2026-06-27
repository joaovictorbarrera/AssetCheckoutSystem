import { Component, Input, ViewChild } from '@angular/core'
import { DatePipe } from '@angular/common'
import { Dropdown } from '../../../../core/components/dropdown/dropdown'
import { AuthService } from '../../../../core/services/auth.service'
import User from '../../../../core/DTOs/user.dto'
import { Role } from '../../../../core/enums/role'

@Component({
  selector: 'tr[app-user-row]',
  imports: [DatePipe, Dropdown],
  templateUrl: './user-row.html',
  styleUrl: './user-row.scss',
})
export class UserRow {
  @Input() user!: User
  @Input() roles: string[] = []
  @ViewChild('roleDropdown') roleDropdown!: Dropdown

  constructor(private authService: AuthService) {}

  get isCurrentUser(): boolean {
    return this.authService.currentUser()?.emailAddress === this.user.emailAddress
  }

  toggleActive(event: Event) {
    const checkbox = event.target as HTMLInputElement

    if (this.isCurrentUser) {
      const confirmed = window.confirm(
        'Warning: You are about to deactivate your own account. You will lose access immediately. Are you sure?'
      )
      if (!confirmed) {
        checkbox.checked = this.user.isActive
        return
      }
    }
    this.user.isActive = checkbox.checked
  }

  handleRoleChange(role: string) {
    if (this.isCurrentUser) {
      const confirmed = window.confirm(
        'Warning: You are about to change your own role. As an admin, changing this role may result in loss of access. Are you sure?'
      )
      if (!confirmed) {
        this.roleDropdown.revert()
        return
      }
    }
    this.user.role = role as Role
  }
}
