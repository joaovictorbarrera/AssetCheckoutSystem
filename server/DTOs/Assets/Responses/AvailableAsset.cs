namespace AssetManagementSystem.DTOs.Assets.Responses
{
    public class AvailableAsset
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string AssetTag { get; set; }
    }
}
