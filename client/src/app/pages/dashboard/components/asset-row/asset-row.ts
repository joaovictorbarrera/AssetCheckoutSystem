import { Component, HostListener, Input, OnInit } from '@angular/core'
import { AssetDto } from '../../../../core/DTOs/asset/asset.dto'
import { CheckoutRequestService } from '../../../../core/services/api/checkout-requests.service'
import { DrawerService } from '../../../../core/services/util/drawer.service'
import { AssetDetail } from '../../../../core/components/drawers/asset-detail/asset-detail'
import { Labels } from '../../../../core/constants/labels'

@Component({
  selector: 'tr[app-asset-row]',
  imports: [],
  templateUrl: './asset-row.html',
  styleUrl: './asset-row.scss',
})
export class AssetRow implements OnInit {
  @Input() asset!: AssetDto

  assetCategoryLabel = ''
  assetStatusLabel = ''

  constructor(
    private requestService: CheckoutRequestService,
    private drawer: DrawerService,
  ) {}

  ngOnInit(): void {
    this.assetCategoryLabel = Labels.assetCategories[this.asset.category]
    this.assetStatusLabel = Labels.assetStatuses[this.asset.status]
  }

  handleReturnRequest() {
    const reason = window.prompt('What is the reason for return?')
    if (reason) {
      this.asset.isPendingReturn = true
      this.requestService
        .create({
          requestType: 'return',
          assetCategory: this.asset.category,
          assetId: this.asset.id,
          reason,
        })
        .subscribe({
          error: (err) => {
            this.asset.isPendingReturn = false
            window.alert(
              `${err.status} error: ` + err.error.title ? err.error.title : 'Unknown Error',
            )
          },
        })
    }
  }

  @HostListener('click')
  viewDetail() {
    this.drawer.open(AssetDetail, { assetId: this.asset.id })
  }
}
