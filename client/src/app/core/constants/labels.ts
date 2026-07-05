export const Labels = {
  assetConditions: {
    new: 'New',
    good: 'Good',
    fair: 'Fair',
    damaged: 'Damaged',
    lost: 'Lost',
  } as Record<string, string>,

  assetStatuses: {
    available: 'Available',
    assigned: 'Assigned',
    maintenance: 'Maintenance',
    retired: 'Retired',
    requested: 'Requested',
  } as Record<string, string>,

  assetCategories: {
    laptop: 'Laptop',
    monitor: 'Monitor',
    phone: 'Phone',
    tablet: 'Tablet',
    dockingStation: 'Docking Station',
    headset: 'Headset',
    securityKey: 'Security Key',
    keyboard: 'Keyboard',
    mouse: 'Mouse',
    other: 'Other',
  } as Record<string, string>,

  requestStatuses: {
    pending: 'Pending',
    approved: 'Approved',
    rejected: 'Rejected',
    fulfilled: 'Fulfilled',
    cancelled: 'Cancelled',
    returned: 'Returned',
  } as Record<string, string>,

  requestTypes: {
    checkout: 'Checkout',
    return: 'Return',
  } as Record<string, string>,

  roles: {
    employee: 'Employee',
    assetManager: 'Asset Manager',
    admin: 'Administrator',
  } as Record<string, string>,
} as const
