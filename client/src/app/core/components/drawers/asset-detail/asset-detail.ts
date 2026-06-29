import { Component, EventEmitter, Input, OnInit, Output, signal } from '@angular/core';
import { AssetService } from '../../../services/api/asset.service';
import { AssetDetailDto } from '../../../DTOs/asset/asset-detail.dto';
import { SpinningWheel } from '../../spinning-wheel/spinning-wheel';
import { AuthService } from '../../../services/api/auth.service';
import { DatePipe } from '@angular/common';
import { Dropdown } from '../../dropdown/dropdown';
import AssetFields from '../../../DTOs/asset/asset-fields.dto';
import { DrawerService } from '../../../services/util/drawer.service';
import { AssetEventsService } from '../../../services/events/asset-events.service';

@Component({
  selector: 'app-asset-detail',
  imports: [SpinningWheel, DatePipe, Dropdown],
  templateUrl: './asset-detail.html',
  styleUrl: './asset-detail.scss',
})
export class AssetDetail implements OnInit {
  @Input() assetId!: string

  assetFields = signal<AssetFields>({categories: [], statuses: [], conditions: []})
  assetDetails = signal<AssetDetailDto | null>(null)
  loadingDetails = signal(true)

  get availableStatuses() {
    return this.assetDetails()?.status === 'assigned'
      ? this.assetFields().statuses
      : this.assetFields().statuses.filter(s => s !== 'assigned');
  }

  constructor(
    private assetService: AssetService,
    public authService: AuthService,
    private assetEvents: AssetEventsService,
    public drawer: DrawerService
  ) {}

  ngOnInit(): void {
    this.getFields()
    this.getDetail()
  }

  getDetail() {
    this.assetService.getDetail(this.assetId).subscribe({
      next: data => {
        this.assetDetails.set(data)
        this.loadingDetails.set(false)
      },
      error: err => {
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }

  getFields() {
    this.assetService.getFields().subscribe({
      next: res => this.assetFields.set(res as AssetFields),
      error: err => window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
    })
  }

  handleArchive() {
    this.assetService.archive(this.assetId).subscribe({
      next: () => {
        this.drawer.close()
        this.assetEvents.emitAssetsChanged()
      },
      error: err => window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
    })
  }
}
