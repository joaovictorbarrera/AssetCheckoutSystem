import { Component, OnInit, signal } from '@angular/core';
import { DrawerService } from '../../../services/util/drawer.service';
import { CheckoutRequestService } from '../../../services/api/checkout-requests.service';
import { AssetService } from '../../../services/api/asset.service';
import AssetFields from '../../../DTOs/asset/asset-fields.dto';
import { FormsModule, NgForm } from '@angular/forms';
import { SubmitButton } from '../../submit-button/submit-button';
import { Dropdown } from '../../dropdown/dropdown';
import { CheckoutRequestEventsService } from '../../../services/events/checkout-request-events.service';

@Component({
  selector: 'app-request-create',
  imports: [FormsModule, SubmitButton, Dropdown],
  templateUrl: './request-create.html',
  styleUrl: './request-create.scss',
})
export class RequestCreate implements OnInit {

  category = signal("laptop")
  reason = ""

  loading = signal(false)
  assetFields = signal<AssetFields>({categories: [], statuses: [], conditions: []})

  constructor(
    public drawer: DrawerService,
    private requestService: CheckoutRequestService,
    private assetService: AssetService,
    private requestEventsService: CheckoutRequestEventsService
  ) {}

  ngOnInit(): void {
    this.getFields()
  }

  handleCategoryChange(category: string) {
    this.category.set(category)
  }

  getFields() {
    this.assetService.getFields().subscribe({
      next: res => this.assetFields.set(res as AssetFields),
      error: err => window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
    })
  }

  submit(form: NgForm) {
    console.log("submitted")
    if (form.invalid) return
    this.loading.set(true)
    this.requestService.create({
      type: 'checkout',
      reason: this.reason,
      category: this.category()
    }).subscribe({
      next: () => {
        this.loading.set(false)
        this.drawer.close()
        this.requestEventsService.emitCheckoutRequestsChanged()
      },
      error: err => {
        this.loading.set(false)
        window.alert(`${err.status} error: ` + err.error.title ? err.error.title : "Unknown Error")
      }
    })
  }
}
