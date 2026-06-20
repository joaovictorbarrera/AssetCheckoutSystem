using System.ComponentModel.DataAnnotations;
using AssetManagementSystem.Enums;

namespace AssetManagementSystem.DTOs.Users
{
    public class CreateUserRequest
    {
        [EmailAddress]
        public required string EmailAddress { get; set; }

        public required Role Role { get; set; }

        [MaxLength(50)]
        [MinLength(2)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        [MinLength(2)]
        public required string LastName { get; set; }
    }
}
