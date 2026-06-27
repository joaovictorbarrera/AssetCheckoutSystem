import { Component, Input } from '@angular/core';
import { Asset } from '../../../../core/DTOs/asset.dto';
import { CheckoutRequestService } from '../../../../core/services/checkout-requests.service';
import { Dropdown } from '../../../../core/components/dropdown/dropdown';
import AssetFields from '../../../../core/DTOs/asset-fields.dto';

@Component({
  selector: 'tr[app-inventory-row]',
  imports: [Dropdown],
  templateUrl: './inventory-row.html',
  styleUrl: './inventory-row.scss',
})
export class InventoryRow {
  @Input() asset!: Asset
  @Input() assetFields!: AssetFields

  constructor(private requestService: CheckoutRequestService) {}
}
