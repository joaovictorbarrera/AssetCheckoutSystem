using AssetCheckoutSystem.DTOs.Pagination;
using AssetCheckoutSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace AssetCheckoutSystem.DTOs.Assets.Requests
{
    public class GetAssetsRequest : PaginatedRequest
    {
        [MaxLength(50)]
        public string? SearchText { get; set; } = "";
        public AssetStatus? Status { get; set; } = null;
        public AssetCondition? Condition { get; set; } = null;
        public AssetCategory? Category { get; set; } = null;

        // ALL below are protected by Manager+ Role
        public bool Inventory { get; set; } = false;
        public bool IncludeArchived { get; set; } = false;
    }
}
