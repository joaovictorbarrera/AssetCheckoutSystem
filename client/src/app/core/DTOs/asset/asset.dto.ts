export interface AssetDto {
  id: string
  assetTag: string
  name: string
  category: string
  status: string
  condition: string
  assignedToUserId?: string
  userFirstName?: string,
  userLastName?: string,
  isArchived: boolean
  isPendingReturn: boolean
}
