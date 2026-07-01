import { Component, Input, OnInit, signal } from '@angular/core';
import { DrawerService } from '../../../services/util/drawer.service';
import { AuthService } from '../../../services/api/auth.service';
import { CheckoutRequestService } from '../../../services/api/checkout-requests.service';
import { CheckoutRequestDetailDto } from '../../../DTOs/checkout-request/checkout-request-detail.dto';
import { SpinningWheel } from "../../spinning-wheel/spinning-wheel";
import { DatePipe } from '@angular/common';
import AvailableAssetDto from '../../../DTOs/asset/available-asset.dto';
import { AssetService } from '../../../services/api/asset.service';
import { CheckoutRequestEventsService } from '../../../services/events/checkout-request-events.service';
import { SubmitButton } from "../../submit-button/submit-button";
import LabelValuePair from '../../../DTOs/shared/label-value-pair';
import { Dropdown } from "../../dropdown/dropdown";

@Component({
  selector: 'app-checkout-request-detail',
  imports: [SpinningWheel, DatePipe, SubmitButton, Dropdown],
  templateUrl: './checkout-request-detail.html',
  styleUrl: './checkout-request-detail.scss',
})
export class CheckoutRequestDetail implements OnInit {
  @Input() requestId!: string

  requestDetails = signal<CheckoutRequestDetailDto | null>(null)
  loadingDetails = signal(false)
  availableAssets = signal<LabelValuePair[]>([])

  loadingApprove = signal(false)
  loadingReject = signal(false)
  loadingReturn = signal(false)
  loadingArchive = signal(false)
  loadingAssign = signal(false)

  selectedAssetId = signal('')

  constructor(
      private requestService: CheckoutRequestService,
      public authService: AuthService,
      public drawer: DrawerService,
      private assetService: AssetService,
      private requestEvents: CheckoutRequestEventsService
    ) {}

  ngOnInit(): void {
    this.getDetail()
  }

  assetSelectionChange(assetId: string) {
    this.selectedAssetId.set(assetId)
  }

  getDetail() {
    if (this.loadingDetails()) return
    this.loadingDetails.set(true)

    this.requestService.getDetail(this.requestId).subscribe({
      next: data => {
        this.requestDetails.set(data)
        this.loadingDetails.set(false)

        if (this.authService.isManager && this.requestDetails()?.status === 'approved' ) {
          this.getAvailableAssets()
        }
      },
      error: err => {
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }

  approve() {
    if (this.loadingApprove()) return
    this.loadingApprove.set(true)

    this.requestService.approve(this.requestId).subscribe({
      next: () => {
        this.loadingApprove.set(false)
        this.drawer.close()
        this.requestEvents.emitCheckoutRequestsChanged()
      },
      error: err => {
        this.loadingApprove.set(false)
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }

  reject() {
    if (this.loadingReject()) return
    this.loadingReject.set(true)

    this.requestService.reject(this.requestId).subscribe({
      next: () => {
        this.loadingReject.set(false)
        this.drawer.close()
        this.requestEvents.emitCheckoutRequestsChanged()
      },
      error: err => {
        this.loadingReject.set(false)
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }

  return() {
    if (this.loadingReturn()) return
    this.loadingReturn.set(true)

    this.requestService.return(this.requestId).subscribe({
      next: () => {
        this.loadingReturn.set(false)
        this.drawer.close()
        this.requestEvents.emitCheckoutRequestsChanged()
      },
      error: err => {
        this.loadingReturn.set(false)
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }

  archive() {
    if (this.loadingArchive()) return

    if (!window.confirm("Are you sure you want to archive this request?")) return

    this.loadingArchive.set(true)

    this.requestService.archive(this.requestId).subscribe({
      next: () => {
        this.loadingArchive.set(false)
        this.drawer.close()
        this.requestEvents.emitCheckoutRequestsChanged()
      },
      error: err => {
        this.loadingArchive.set(false)
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }

  assign() {
    if (this.loadingAssign()) return

    this.loadingAssign.set(true)

    this.requestService.assignAsset(this.requestId, {
      assetId: this.selectedAssetId()
    }).subscribe({
      next: () => {
        this.loadingAssign.set(false)
        this.drawer.close()
        this.requestEvents.emitCheckoutRequestsChanged()
      },
      error: err => {
        this.loadingAssign.set(false)
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }

  getAvailableAssets() {
    this.assetService.getAvailable(this.requestDetails()!.assetCategory).subscribe({
      next: data => {
        this.availableAssets.set(data.map(a => { return {label: `${a.name} (${a.assetTag})`, value: a.id} }))
      },
      error: err => {
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }
}
