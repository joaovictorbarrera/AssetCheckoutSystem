using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Data;
using AssetManagementSystem.DTOs.Pagination;
using AssetManagementSystem.DTOs.Users;
using AssetManagementSystem.Enums;
using AssetManagementSystem.Models.Entities;

namespace AssetManagementSystem.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<User>> GetUsersAsync(GetUsersRequest request)
        {
            IQueryable<User> query = _context.Users;

            if (request.HideInactive)
            {
                query = query.Where(u => u.IsActive);
            }

            int totalCount = await query.CountAsync();

            List<User> users = await query
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            int totalPages = (int) Math.Ceiling((double) totalCount / request.PageSize);

            return new PagedResponse<User>
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

        public async Task<User> CreateUserAsync(CreateUserRequest request)
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

            return user;
        }
        public Task<User?> GetUserByEmailAsync(string email)
        {
            return _context.Users
                .FirstOrDefaultAsync(u => u.EmailAddress == email);
        }

        public Task<User?> GetUserByIdAsync(Guid id)
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

        public async Task<User?> UpdateUserRole(Guid id, Role role)
        {
            User? user = await GetUserByIdAsync(id);

            if (user == null) return null;

            user.Role = role;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> UpdateUserActive(Guid id, bool isActive)
        {
            User? user = await GetUserByIdAsync(id);

            if (user == null) return null;

            user.IsActive = isActive;

            await _context.SaveChangesAsync();

            return user;
        }

        
    }
}