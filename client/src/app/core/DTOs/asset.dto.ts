import User from "./user.dto";

export interface Asset {
  id: string
  assetTag: string
  name: string
  category: string
  status: string
  condition: string
  assignedToUserId?: string | null
  assignedToUser?: User | null
  isArchived: boolean
  isPendingReturn: boolean
}
