using AssetCheckoutSystem.DTOs.Users.Responses;
using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Models.Entities;
using System.Linq.Expressions;

namespace AssetCheckoutSystem.DTOs.Users.Projections
{
    public class UserExpressions
    {
        public static Expression<Func<User, UserDto>> ToDto =>
            u => new UserDto
            {
                Id = u.Id,
                EmailAddress = u.EmailAddress,
                Role = u.Role,
                IsActive = u.IsActive,
                LastLoginAt = u.LastLoginAt,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                FirstName = u.FirstName,
                LastName = u.LastName
            };
    }
}
