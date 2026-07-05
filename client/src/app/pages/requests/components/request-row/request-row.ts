import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core'
import { CheckoutRequestDto } from '../../../../core/DTOs/checkout-request/checkout-request.dto'
import { DatePipe } from '@angular/common'
import { CheckoutRequestService } from '../../../../core/services/api/checkout-requests.service'
import { DrawerService } from '../../../../core/services/util/drawer.service'
import { CheckoutRequestDetail } from '../../../../core/components/drawers/checkout-request-detail/checkout-request-detail'
import { Labels } from '../../../../core/constants/labels'

@Component({
  selector: 'tr[app-request-row]',
  imports: [DatePipe],
  templateUrl: './request-row.html',
  styleUrl: './request-row.scss',
})
export class RequestRow implements OnInit {
  @Input() request!: CheckoutRequestDto
  @Output() cancelled = new EventEmitter<string>()

  requestTypeLabel = ''
  requestStatusLabel = ''
  assetCategoryLabel = ''

  constructor(
    private requestService: CheckoutRequestService,
    private drawer: DrawerService,
  ) {}

  ngOnInit(): void {
    this.requestTypeLabel = Labels.requestTypes[this.request.requestType]
    this.requestStatusLabel = Labels.requestStatuses[this.request.status]
    this.assetCategoryLabel = Labels.assetCategories[this.request.assetCategory]
  }

  handleCancel() {
    if (window.confirm('Are you sure you want to cancel this request?')) {
      this.requestService.cancel(this.request.id).subscribe({
        next: () => this.cancelled.emit(this.request.id),
        error: (err) =>
          window.alert(
            `${err.status} error: ` + err.error.title ? err.error.title : 'Unknown Error',
          ),
      })
    }
  }

  @HostListener('click')
  openRequestDetail() {
    this.drawer.open(CheckoutRequestDetail, { requestId: this.request.id })
  }
}
