import { DatePipe } from '@angular/common';
import { Component, HostListener, Input, OnInit } from '@angular/core';
import { CheckoutRequestDto } from '../../../../core/DTOs/checkout-request/checkout-request.dto';
import { CheckoutRequestDetail } from '../../../../core/components/drawers/checkout-request-detail/checkout-request-detail';
import { DrawerService } from '../../../../core/services/util/drawer.service';
import { Labels } from '../../../../core/constants/labels';

@Component({
  selector: 'tr[app-review-row]',
  imports: [DatePipe],
  templateUrl: './review-row.html',
  styleUrl: './review-row.scss',
})
export class ReviewRow implements OnInit {
  @Input() request!: CheckoutRequestDto

  requestTypeLabel = ''
  requestStatusLabel = ''
  assetCategoryLabel = ''

  constructor(private drawer: DrawerService) {}

  ngOnInit(): void {
    this.requestTypeLabel = Labels.requestTypes[this.request.requestType]
    this.requestStatusLabel = Labels.requestStatuses[this.request.status]
    this.assetCategoryLabel = Labels.assetCategories[this.request.assetCategory]
  }

  @HostListener("click")
  openRequestDetail() {
    this.drawer.open(CheckoutRequestDetail, { requestId: this.request.id})
  }
}
