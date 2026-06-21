using AssetManagementSystem.Enums;

namespace AssetManagementSystem.DTOs.Assets.Requests
{
    public class GetAvailableAssets
    {
        public required AssetCategory Category { get; set; }
    }
}
