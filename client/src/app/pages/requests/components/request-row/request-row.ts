import { Component, Input } from '@angular/core';
import { CheckoutRequest } from '../../../../core/DTOs/checkout-request.dto';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'tr[app-request-row]',
  imports: [DatePipe],
  templateUrl: './request-row.html',
  styleUrl: './request-row.scss',
})
export class RequestRow {
  @Input() request!: CheckoutRequest
}
