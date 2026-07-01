using AssetManagementSystem.DTOs.Pagination;
using AssetManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.Users
{
    public class GetUsersRequest : PaginatedRequest
    {
        [MaxLength(50)]
        public string? SearchText { get; set; } = "";
        public Role? Role { get; set; }
        public bool ShowInactive { get; set; } = false;
    }
}
