using AssetCheckoutSystem.DTOs.Users.Internal;
using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Helpers;

namespace AssetCheckoutSystem.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string EmailAddress { get; set; }
        public required Role Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLoginAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public string? PasswordHash { get; set; }
        public string? PasswordResetTokenHash { get; set; }
        public DateTime? PasswordResetExpiresAt { get; set; }
        public DateTime? PasswordChangedAt { get; set; }
        public string? RefreshTokenHash { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }

        public Requestor GetRequestor()
        {
            return new Requestor
            {
                UserId = Id,
                IsAssetManager = RolesHelper.IsAssetManager(Role)
            };
        }
    }
}
