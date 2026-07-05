using AssetCheckoutSystem.Enums;

namespace AssetCheckoutSystem.DTOs.Assets.Requests
{
    public class UpdateAssetStatusRequest
    {
        public required AssetStatus Status { get; set; }
    }
}
