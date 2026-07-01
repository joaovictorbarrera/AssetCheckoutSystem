import UserDto from "../user/user.dto";

export interface CheckoutRequestDetailDto {
  id: string;
  requestType: string;

  requestedByUser: UserDto;

  reason: string;
  status: string;

  reviewedByUser?: UserDto;

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
