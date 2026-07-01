import { Component, Input, OnInit, signal, ViewChild } from '@angular/core'
import { DatePipe } from '@angular/common'
import { Dropdown } from '../../../../core/components/dropdown/dropdown'
import { AuthService } from '../../../../core/services/api/auth.service'
import UserDto from '../../../../core/DTOs/user/user.dto'
import { Role } from '../../../../core/enums/role'
import { UserService } from '../../../../core/services/api/user.service'
import LabelValuePair from '../../../../core/DTOs/shared/label-value-pair'
import { toLabelValuePairs } from '../../../../core/utils/label.utils'
import { Labels } from '../../../../core/constants/labels'

@Component({
  selector: 'tr[app-user-row]',
  imports: [DatePipe, Dropdown],
  templateUrl: './user-row.html',
  styleUrl: './user-row.scss',
})
export class UserRow implements OnInit {
  @Input() user!: UserDto
  @Input() roles: string[] = []
  @ViewChild('roleDropdown') roleDropdown!: Dropdown

  showRoleSuccess = signal(false)
  showActiveSuccess = signal(false)

  rolesList: LabelValuePair[] = []

  constructor(private authService: AuthService, private userService: UserService) {}

  ngOnInit(): void {
    this.rolesList = toLabelValuePairs(this.roles, Labels.roles)
  }

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

    this.userService.updateActive(this.user.id, checkbox.checked).subscribe({
        next: () => {
            this.user.isActive = checkbox.checked
            this.showActiveSuccess.set(true)
            setTimeout(() => this.showActiveSuccess.set(false), 3000)
        },
        error: err => {
            checkbox.checked = this.user.isActive
            window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
        }
    })
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

    this.userService.updateRole(this.user.id, role).subscribe({
        next: () => {
            this.user.role = role as Role
            this.showRoleSuccess.set(true)
            setTimeout(() => this.showRoleSuccess.set(false), 3000)
        },
        error: err => {
            this.roleDropdown.revert()
            window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
        }
    })
  }
}
