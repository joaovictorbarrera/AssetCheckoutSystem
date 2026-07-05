using AssetCheckoutSystem.Enums;

namespace AssetCheckoutSystem.DTOs.Assets.Requests
{
    public class GetAvailableAssetsRequest
    {
        public required AssetCategory Category { get; set; }
    }
}
