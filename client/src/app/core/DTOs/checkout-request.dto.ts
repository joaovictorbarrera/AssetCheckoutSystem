import { Asset } from "./asset.dto";
import User from "./user.dto";

export interface CheckoutRequest {
  id: string;
  requestType: string;
  requestedByUserId: string;
  requestedByUser: User;
  assetCategory?: string;
  status: string;
  assignedAssetId?: string;
  assignedAsset?: Asset;
  createdAt: Date;
  isArchived: boolean;
}
