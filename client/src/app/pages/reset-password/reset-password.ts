import { Component, OnInit, signal } from '@angular/core'
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms'
import { ActivatedRoute, Router, RouterModule } from '@angular/router'
import { SubmitButton } from '../../core/components/submit-button/submit-button'
import { AuthService } from '../../core/services/api/auth.service'

@Component({
  selector: 'app-reset-password',
  imports: [RouterModule, SubmitButton, ReactiveFormsModule],
  templateUrl: './reset-password.html',
  styleUrl: './reset-password.scss',
})
export class ResetPassword implements OnInit {
  loading = signal(false)
  success = signal(false)

  failMessage = signal<string | null>(null)
  validationErrors = signal<string[]>([])

  resetToken = ''

  form: FormGroup

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private authService: AuthService,
    private router: Router,
  ) {
    this.form = this.fb.group(
      {
        emailAddress: [{ value: '', disabled: true }, [Validators.required, Validators.email]],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(8),
            Validators.pattern(/^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$/),
          ],
        ],
        confirmPassword: ['', Validators.required],
      },
      {
        validators: this.passwordsMatchValidator,
      },
    )
  }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe((params) => {
      this.resetToken = params.get('resetToken') ?? ''

      this.form.patchValue({
        emailAddress: params.get('email') ?? '',
      })
    })
  }

  private passwordsMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password')?.value
    const confirmPassword = control.get('confirmPassword')?.value

    return password === confirmPassword ? null : { passwordsDoNotMatch: true }
  }

  resetPassword(event: Event): void {
    event.preventDefault()

    this.failMessage.set(null)
    this.validationErrors.set([])

    const errors: string[] = []

    if (!this.resetToken) {
      errors.push('The password reset link is invalid.')
    }

    if (this.password.hasError('required')) {
      errors.push('Password is required.')
    }

    if (this.password.hasError('minlength')) {
      errors.push('Password must be at least 8 characters.')
    }

    if (this.password.hasError('pattern')) {
      errors.push(
        'Password must contain at least one uppercase letter, one number, and one special character.',
      )
    }

    if (this.confirmPassword.hasError('required')) {
      errors.push('Please confirm your password.')
    }

    if (this.form.hasError('passwordsDoNotMatch')) {
      errors.push('Passwords do not match.')
    }

    this.validationErrors.set(errors)

    if (errors.length > 0) {
      return
    }

    this.loading.set(true)

    this.authService
      .resetPassword({
        emailAddress: this.form.getRawValue().emailAddress,
        password: this.password.value,
        resetToken: this.resetToken,
      })
      .subscribe({
        next: () => {
          this.loading.set(false)
          this.success.set(true)
          this.failMessage.set(null)
          this.validationErrors.set([])
          setTimeout(() => this.router.navigate(['/login']), 3000)
        },
        error: (err) => {
          this.loading.set(false)
          this.failMessage.set(err.error?.message ?? 'Unable to reset password.')
        },
      })
  }

  get password(): AbstractControl {
    return this.form.get('password')!
  }

  get confirmPassword(): AbstractControl {
    return this.form.get('confirmPassword')!
  }
}
