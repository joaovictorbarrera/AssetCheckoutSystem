using AssetManagementSystem.DTOs.Auth.Internal;
using AssetManagementSystem.DTOs.Auth.Requests;
using AssetManagementSystem.DTOs.Auth.Responses;
using AssetManagementSystem.DTOs.Pagination;
using AssetManagementSystem.DTOs.Users;
using AssetManagementSystem.DTOs.Users.Internal;
using AssetManagementSystem.DTOs.Users.Requests;
using AssetManagementSystem.DTOs.Users.Responses;
using AssetManagementSystem.Enums;
using AssetManagementSystem.Helpers;
using AssetManagementSystem.Models.Entities;
using AssetManagementSystem.Repositories;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AssetManagementSystem.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public UserService(
            UserRepository userRepository, 
            TokenService tokenService,
            IConfiguration configuration
        ){
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<ServiceResult<PagedResponse<UserDto>>> Get(GetUsersRequest request)
        {
            PagedResponse<UserDto> users = await _userRepository.GetUsersAsync(request);

            return ServiceResult<PagedResponse<UserDto>>.Success(users);
        }

        public async Task<ServiceResult<Guid>> Create(CreateUserRequest request)
        {
            bool userExists = await _userRepository.GetUserByEmailAsync(request.EmailAddress) != null;
            if (userExists) return ServiceResult<Guid>.BadRequest("Email Address is taken");

            Guid newUserId = await _userRepository.CreateUserAsync(request);

            return ServiceResult<Guid>.Success(newUserId);
        }

        public async Task<ServiceResult> UpdateRole(Guid id, UpdateUserRoleRequest request)
        {
            bool success = await _userRepository.UpdateUserRole(id, request.Role);

            return success ? ServiceResult.Success() : ServiceResult.NotFound();
        }

        public async Task<ServiceResult> UpdateActive(Guid id, UpdateUserActiveRequest request)
        {
            bool success = await _userRepository.UpdateUserActive(id, request.IsActive);

            return success ? ServiceResult.Success() : ServiceResult.NotFound();
        }

        public async Task<ServiceResult<AccessTokenDto>> Login(LoginRequest request, HttpResponse response)
        {
            User? user = await _userRepository.GetUserByEmailAsync(request.EmailAddress);

            //  || user.PasswordHash != EncryptionHelper.ToSha256(request.Password)
            if (user == null || !user.IsActive)
            {
                return ServiceResult<AccessTokenDto>.Unauthorized();
            }

            AccessTokenDto tokenDto = _tokenService.CreateToken(user);
            RefreshTokenDto refreshTokenDto = _tokenService.CreateRefreshToken();

            await _userRepository.SaveRefreshToken(user, refreshTokenDto);
            await _userRepository.UpdateLastLoginAsync(user.Id);

            response.Cookies.Append(
                "refreshToken",
                refreshTokenDto.RefreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(_configuration.GetValue("RefreshTokenExpirationDays", 7))
                }
            );

            return ServiceResult<AccessTokenDto>.Success(tokenDto);
        }

        public async Task<ServiceResult<AccessTokenDto>> Refresh(User user, string refreshToken, HttpResponse response)
        {
            bool validRefreshToken = user.RefreshTokenExpiresAt >= DateTime.UtcNow && user.RefreshTokenHash == EncryptionHelper.ToSha256(refreshToken);

            if (!validRefreshToken) return ServiceResult<AccessTokenDto>.Unauthorized();

            AccessTokenDto tokenDto = _tokenService.CreateToken(user);
            RefreshTokenDto refreshTokenDto = _tokenService.CreateRefreshToken();

            await _userRepository.SaveRefreshToken(user, refreshTokenDto);

            response.Cookies.Append(
                "refreshToken",
                refreshTokenDto.RefreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(_configuration.GetValue("RefreshTokenExpirationDays", 7))
                }
            );

            return ServiceResult<AccessTokenDto>.Success(tokenDto);
        }
    }
}
