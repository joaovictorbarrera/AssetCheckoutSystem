using AssetManagementSystem.Enums;

namespace AssetManagementSystem.DTOs.Assets.Requests
{
    public class UpdateAssetCategoryRequest
    {
        public required AssetCategory Category { get; set; }
    }
}
