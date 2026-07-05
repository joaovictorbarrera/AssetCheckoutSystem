using AssetCheckoutSystem.DTOs.Pagination;
using AssetCheckoutSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace AssetCheckoutSystem.DTOs.Users.Requests
{
    public class GetUsersRequest : PaginatedRequest
    {
        [MaxLength(50)]
        public string? SearchText { get; set; } = "";
        public Role? Role { get; set; }
        public bool ShowInactive { get; set; } = false;
    }
}
