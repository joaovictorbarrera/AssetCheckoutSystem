using AssetCheckoutSystem.Enums;

namespace AssetCheckoutSystem.DTOs.Assets.Requests
{
    public class UpdateAssetCategoryRequest
    {
        public required AssetCategory Category { get; set; }
    }
}
