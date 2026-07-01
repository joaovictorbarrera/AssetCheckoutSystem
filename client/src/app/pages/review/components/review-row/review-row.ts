import { DatePipe } from '@angular/common';
import { Component, HostListener, Input } from '@angular/core';
import { CheckoutRequestDto } from '../../../../core/DTOs/checkout-request/checkout-request.dto';
import { CheckoutRequestDetail } from '../../../../core/components/drawers/checkout-request-detail/checkout-request-detail';
import { DrawerService } from '../../../../core/services/util/drawer.service';

@Component({
  selector: 'tr[app-review-row]',
  imports: [DatePipe],
  templateUrl: './review-row.html',
  styleUrl: './review-row.scss',
})
export class ReviewRow {
  @Input() request!: CheckoutRequestDto

  constructor(private drawer: DrawerService) {}

  @HostListener("click")
  openRequestDetail() {
    this.drawer.open(CheckoutRequestDetail, { requestId: this.request.id})
  }
}
