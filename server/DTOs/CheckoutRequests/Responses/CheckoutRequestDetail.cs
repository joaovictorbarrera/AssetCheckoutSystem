using AssetCheckoutSystem.DTOs.Assets.Responses;
using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Models.Entities;

namespace AssetCheckoutSystem.DTOs.CheckoutRequests
{
    public class CheckoutRequestDetail
    {
        public required Guid Id { get; set; }
        public required CheckoutRequestType RequestType { get; set; }

        public required Guid RequestorId { get; set; }
        public required string RequestorFirstName { get; set; }
        public required string RequestorLastName { get; set; }
        public required string RequestorEmail { get; set; }

        public required string Reason { get; set; }
        public required CheckoutRequestStatus Status { get; set; }

        public Guid? ReviewerId { get; set; }
        public string? ReviewerFirstName { get; set; }
        public string? ReviewerLastName { get; set; }
        public string? ReviewerEmail { get; set; }

        public required AssetCategory AssetCategory { get; set; } 
        public Guid? AssignedAssetId { get; set; }
        public string? AssignedAssetName { get; set; }
        public string? AssignedAssetTag { get; set; }

        public DateTime? ApprovedAt { get; set; }
        public DateTime? RejectedAt { get; set; }
        public DateTime? FulfilledAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsArchived { get; set; }
    }
}
