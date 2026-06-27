import { TitleCasePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-dropdown',
  imports: [FormsModule, TitleCasePipe],
  templateUrl: './dropdown.html',
  styleUrl: './dropdown.scss',
})
export class Dropdown implements OnChanges {
  @Input() name!: string
  @Input() list!: string[]
  @Input() defaultSelected?: string
  @Output() dropdownChanged = new EventEmitter<string>()

  value = 'all'

  ngOnChanges(changes: SimpleChanges) {
    if (changes['defaultSelected'] && this.defaultSelected !== undefined) {
      this.value = this.defaultSelected
    }
  }

  onChange() {
    this.dropdownChanged.emit(this.value)
  }
}
