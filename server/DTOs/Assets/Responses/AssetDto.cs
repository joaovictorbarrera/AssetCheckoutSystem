using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Models.Entities;

namespace AssetCheckoutSystem.DTOs.Assets.Responses
{
    public class AssetDto
    {
        public Guid Id { get; set; }

        public required string AssetTag { get; set; }
        public required string Name { get; set; }

        public required AssetCategory Category { get; set; }
        public required AssetStatus Status { get; set; }
        public required AssetCondition Condition { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public bool IsArchived { get; set; } = false;
        public bool IsPendingReturn { get; set; } = false;
    }
}
