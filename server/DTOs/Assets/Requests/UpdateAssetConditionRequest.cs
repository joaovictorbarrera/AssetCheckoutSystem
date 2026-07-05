using AssetCheckoutSystem.Enums;

namespace AssetCheckoutSystem.DTOs.Assets.Requests
{
    public class UpdateAssetConditionRequest
    {
        public required AssetCondition Condition { get; set; }
    }
}
