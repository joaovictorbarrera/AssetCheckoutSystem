using AssetManagementSystem.DTOs.Assets.Responses;
using AssetManagementSystem.Enums;
using AssetManagementSystem.Models.Entities;

namespace AssetManagementSystem.DTOs.CheckoutRequests
{
    public class CheckoutRequestDto
    {
        public Guid Id { get; set; }
        public required CheckoutRequestType RequestType { get; set; }

        public required Guid RequestedByUserId { get; set; }
        public User RequestedByUser { get; set; } = null!;

        public AssetCategory? AssetCategory { get; set; }
        public required CheckoutRequestStatus Status { get; set; }

        public Guid? AssignedAssetId { get; set; }
        public AssetDto? AssignedAsset { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsArchived { get; set; } = false;
    }
}
