using AssetManagementSystem.Enums;

namespace AssetManagementSystem.DTOs.CheckoutRequests
{
    public class CheckoutRequestFields
    {
        public List<string> Statuses { get; set; } = [.. Enum.GetNames(typeof(CheckoutRequestStatus)).Select(s => s.ToLower())];
        public List<string> Types { get; set; } = [.. Enum.GetNames(typeof(CheckoutRequestType)).Select(t => t.ToLower())];
    }
}
