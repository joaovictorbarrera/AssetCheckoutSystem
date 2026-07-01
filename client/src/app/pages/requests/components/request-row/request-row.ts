import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { CheckoutRequestDto } from '../../../../core/DTOs/checkout-request/checkout-request.dto';
import { DatePipe } from '@angular/common';
import { CheckoutRequestService } from '../../../../core/services/api/checkout-requests.service';
import { DrawerService } from '../../../../core/services/util/drawer.service';
import { CheckoutRequestDetail } from '../../../../core/components/drawers/checkout-request-detail/checkout-request-detail';

@Component({
  selector: 'tr[app-request-row]',
  imports: [DatePipe],
  templateUrl: './request-row.html',
  styleUrl: './request-row.scss',
})
export class RequestRow {
  @Input() request!: CheckoutRequestDto
  @Output() cancelled = new EventEmitter<string>();

  constructor(
    private requestService: CheckoutRequestService,
    private drawer: DrawerService
  ) {}

  handleCancel() {
    if (window.confirm("Are you sure you want to cancel this request?")) {
      this.requestService.cancel(this.request.id).subscribe({
        next: () => this.cancelled.emit(this.request.id),
        error: err => window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      })
    }
  }

  @HostListener("click")
  openRequestDetail() {
    this.drawer.open(CheckoutRequestDetail, { requestId: this.request.id})
  }
}


