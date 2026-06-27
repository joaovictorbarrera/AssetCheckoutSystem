using AssetManagementSystem.Enums;

namespace AssetManagementSystem.DTOs.Assets.Responses
{
    public class AssetFields
    {
        public List<string> Conditions { get; } = [.. Enum.GetNames(typeof(AssetCondition)).Select(t => t.ToLower())];

        public List<string> Statuses { get; } = [.. Enum.GetNames(typeof(AssetStatus)).Select(t => t.ToLower())];

        public List<string> Categories { get; } = [.. Enum.GetNames(typeof(AssetCategory)).Select(t => t.ToLower())];
    }
}
