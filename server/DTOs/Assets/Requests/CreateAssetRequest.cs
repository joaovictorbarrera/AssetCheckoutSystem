using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace AssetCheckoutSystem.DTOs.Assets.Requests
{
    public class CreateAssetRequest
    {
        [MaxLength(50)]
        [MinLength(1)]
        public required string AssetTag { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        public required string Name { get; set; }

        [MaxLength(50)]
        public string? SerialNumber { get; set; }
        public required AssetCategory Category { get; set; }
        public required AssetCondition Condition { get; set; }
    }
}
