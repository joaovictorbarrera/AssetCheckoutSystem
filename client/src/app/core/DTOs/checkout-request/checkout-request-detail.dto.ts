export interface CheckoutRequestDetailDto {
  id: string;
  requestType: string;

  requestorId: string;
  requestorFirstName: string;
  requestorLastName: string;
  requestorEmail: string;

  reason: string;
  status: string;

  reviewerId?: string;
  reviewerFirstName?: string;
  reviewerLastName?: string;
  reviewerEmail?: string;

  assetCategory: string;
  assignedAssetId?: string;
  assignedAssetName?: string;
  assignedAssetTag?: string;

  approvedAt?: string;
  rejectedAt?: string;
  fulfilledAt?: string;
  returnedAt?: string;
  updatedAt?: string;
  createdAt: string;

  isArchived: boolean;
}
