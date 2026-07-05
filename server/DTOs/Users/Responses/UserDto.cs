using AssetCheckoutSystem.Enums;

namespace AssetCheckoutSystem.DTOs.Users.Responses
{
    public class UserDto
    {
        public required Guid Id { get; set; }
        public required string EmailAddress { get; set; }
        public required Role Role { get; set; }
        public required bool IsActive { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
