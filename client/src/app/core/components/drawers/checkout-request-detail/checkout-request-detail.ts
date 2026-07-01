import { Component, Input, OnInit, signal } from '@angular/core';
import { DrawerService } from '../../../services/util/drawer.service';
import { AuthService } from '../../../services/api/auth.service';
import { CheckoutRequestService } from '../../../services/api/checkout-requests.service';
import { CheckoutRequestDetailDto } from '../../../DTOs/checkout-request/checkout-request-detail.dto';
import { SpinningWheel } from "../../spinning-wheel/spinning-wheel";
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-checkout-request-detail',
  imports: [SpinningWheel, DatePipe],
  templateUrl: './checkout-request-detail.html',
  styleUrl: './checkout-request-detail.scss',
})
export class CheckoutRequestDetail implements OnInit {
  @Input() requestId!: string

  requestDetails = signal<CheckoutRequestDetailDto | null>(null)
  loadingDetails = signal(false)

  constructor(
      private requestService: CheckoutRequestService,
      public authService: AuthService,
      public drawer: DrawerService
    ) {}

  ngOnInit(): void {
    this.getDetail()
  }

  getDetail() {
    if (this.loadingDetails()) return
    this.loadingDetails.set(true)

    this.requestService.getDetail(this.requestId).subscribe({
      next: data => {
        this.requestDetails.set(data)
        this.loadingDetails.set(false)
      },
      error: err => {
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }
}
