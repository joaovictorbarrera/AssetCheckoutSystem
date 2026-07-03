export interface CheckoutRequestDto {
  id: string
  requestType: string

  requestorId: string
  requestorFirstName: string
  requestorLastName: string
  requestorEmail: string

  status: string

  assignedAssetId?: string
  assetCategory: string
  assignedAssetName?: string
  assignedAssetTag?: string

  createdAt: string
  isArchived: boolean
}
