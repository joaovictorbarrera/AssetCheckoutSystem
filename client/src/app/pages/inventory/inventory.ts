import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { Page } from "../components/page/page";
import { PageHeader } from '../components/page-header/page-header';
import { AssetService } from '../../core/services/asset.service';
import AssetFields from '../../core/DTOs/asset-fields.dto';
import { Dropdown } from "../../core/components/dropdown/dropdown";
import { SearchBar } from "../../core/components/search-bar/search-bar";
import { InventoryTable } from "./components/inventory-table/inventory-table";
import PaginatedResponse, { defaultPaginatedResponse } from '../../core/DTOs/paginated.response';
import { Asset } from '../../core/DTOs/asset.dto';
import { TablePagination } from "../../core/components/table-components/table-pagination/table-pagination";

@Component({
  selector: 'app-inventory',
  imports: [Page, PageHeader, Dropdown, SearchBar, InventoryTable, TablePagination],
  templateUrl: './inventory.html',
  styleUrl: './inventory.scss',
})
export class Inventory implements OnInit {
  assetFields: WritableSignal<AssetFields> = signal({categories: [], statuses: [], conditions: []})
  headers = ["Asset Tag", "Name", "Category", "Status", "Assigned To", "Condition"]
  assets = signal(defaultPaginatedResponse<Asset>())

  category = signal("")
  status = signal("")
  condition = signal("")

  searchText = signal("")
  includeArchived = signal(false)

  pageSize = signal(25)
  pageNumber = signal(1)

  loadingAssets = signal(false)

  constructor(private assetService: AssetService) {}

  ngOnInit(): void {
    this.getFields()
    this.getAssets()
  }

  handleIncludeArchived(event: Event) {
    const target = event?.target as HTMLInputElement | null
    this.includeArchived.set(target?.checked ?? false)
    this.getAssets()
  }

  handleSearch(searchText: string) {
    this.searchText.set(searchText)
    this.getAssets()
  }

  handleStatusChange(status: string) {
    this.status.set(status === "all" ? "" : status)
    this.getAssets()
  }

  handleCategoryChange(category: string) {
    this.category.set(category === "all" ? "" : category)
    this.getAssets()
  }

  handleConditionChange(condition: string) {
    this.condition.set(condition === "all" ? "" : condition)
  }

  handlePaginationChange(pagination: { pageNumber: number; pageSize: number }) {
    this.pageNumber.set(pagination.pageNumber)
    this.pageSize.set(pagination.pageSize)
    this.getAssets()
  }

  getFields() {
    this.assetService.getFields().subscribe({
      next: res => this.assetFields.set(res as AssetFields),
      error: err => window.alert(err.message)
    })
  }

  getAssets() {
    if (this.loadingAssets()) return

    this.loadingAssets.set(true)
    this.assetService.getAssets({
      pageNumber: this.pageNumber(),
      pageSize: this.pageSize(),
      searchText: this.searchText(),
      status: this.status(),
      condition: this.condition(),
      category: this.category(),
      inventory: true,
      includeArchived: this.includeArchived()
    }).subscribe({
      next: data => {
        this.assets.set(data as PaginatedResponse<Asset>)
        this.loadingAssets.set(false)
      },
      error: (err) => {
        window.alert(err.message)
        this.assets.set(defaultPaginatedResponse<Asset>())
        this.loadingAssets.set(false)
      }
    })
  }
}
