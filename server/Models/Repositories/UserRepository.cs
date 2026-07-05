using AssetCheckoutSystem.Data;
using AssetCheckoutSystem.DTOs.Auth.Internal;
using AssetCheckoutSystem.DTOs.Pagination;
using AssetCheckoutSystem.DTOs.Users.Projections;
using AssetCheckoutSystem.DTOs.Users.Requests;
using AssetCheckoutSystem.DTOs.Users.Responses;
using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Helpers;
using AssetCheckoutSystem.Migrations;
using AssetCheckoutSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AssetCheckoutSystem.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<UserDto>> GetUsersAsync(GetUsersRequest request)
        {
            IQueryable<User> query = _context.Users;

            if (!request.ShowInactive)
            {
                query = query.Where(u => u.IsActive);
            }

            if (!String.IsNullOrEmpty(request.SearchText))
            {
                query = query.Where(u => u.FirstName.Contains(request.SearchText) ||
                            u.LastName.Contains(request.SearchText));
            }

            if (request.Role != null)
            {
                query = query.Where(u => u.Role == request.Role);
            }

            int totalCount = await query.CountAsync();

            List<UserDto> users = await query
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(UserExpressions.ToDto)
                .ToListAsync();

            int totalPages = PaginationHelper.GetTotalPageCount(totalCount, request.PageSize);

            return new PagedResponse<UserDto>
            {
                Items = users,
                Pagination = new PaginationMetadata
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    TotalCount = totalCount,
                    TotalPages = totalPages,
                    HasPreviousPage = request.PageNumber > 1,
                    HasNextPage = request.PageNumber < totalPages
                }
            };
        }

        public async Task<Guid> CreateUserAsync(CreateUserRequest request)
        {
            User user = new()
            {
                EmailAddress = request.EmailAddress,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = request.Role
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user.Id;
        }
        public Task<User?> GetByEmail(string email)
        {
            return _context.Users
                .FirstOrDefaultAsync(u => u.EmailAddress == email);
        }

        public Task<User?> GetById(Guid id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateLastLoginAsync(Guid id)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(u =>
                    u.SetProperty(x => x.LastLoginAt, DateTime.UtcNow)
                );
        }

        public async Task<bool> UpdateUserRole(Guid id, Role role)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(u => 
                    u.SetProperty(u => u.Role, role)
                    .SetProperty(x => x.UpdatedAt, DateTime.UtcNow)
                ) > 0;
        }

        public async Task<bool> UpdateUserActive(Guid id, bool isActive)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(u =>
                    u.SetProperty(u => u.IsActive, isActive)
                    .SetProperty(x => x.UpdatedAt, DateTime.UtcNow)
                ) > 0;
        }

        public async Task SaveRefreshToken(User user, RefreshTokenDto refreshTokenDto)
        {
            user.RefreshTokenHash = EncryptionHelper.ToSha256(refreshTokenDto.RefreshToken);
            user.RefreshTokenExpiresAt = refreshTokenDto.ExpiresAt;

            await _context.SaveChangesAsync();
        }

        public async Task ResetPassword(User user, string resetToken, DateTime resetTokenExpiresAt)
        {
            user.PasswordHash = null;
            user.PasswordResetTokenHash = EncryptionHelper.ToSha256(resetToken);
            user.PasswordResetExpiresAt = resetTokenExpiresAt;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task SavePassword(User user, string password)
        {
            user.PasswordHash = EncryptionHelper.ToSha256(password);
            user.PasswordChangedAt = DateTime.UtcNow;
            user.RefreshTokenHash = null;
            user.RefreshTokenExpiresAt = null;
            user.PasswordResetExpiresAt = null;
            user.PasswordResetTokenHash = null;

            await _context.SaveChangesAsync();
        }
    }
}