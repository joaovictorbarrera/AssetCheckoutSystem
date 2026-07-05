import { Component, Input } from '@angular/core'
import { SpinningWheel } from '../spinning-wheel/spinning-wheel'

@Component({
  selector: 'app-submit-button',
  imports: [SpinningWheel],
  templateUrl: './submit-button.html',
})
export class SubmitButton {
  @Input() text!: string
  @Input() loading = false
  @Input() disabled = false
  @Input() color = 'accent'
  @Input() type = 'submit'
}
