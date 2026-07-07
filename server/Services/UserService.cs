using AssetCheckoutSystem.DTOs.Auth.Internal;
using AssetCheckoutSystem.DTOs.Auth.Requests;
using AssetCheckoutSystem.DTOs.Auth.Responses;
using AssetCheckoutSystem.DTOs.Pagination;
using AssetCheckoutSystem.DTOs.Users;
using AssetCheckoutSystem.DTOs.Users.Requests;
using AssetCheckoutSystem.DTOs.Users.Responses;
using AssetCheckoutSystem.Helpers;
using AssetCheckoutSystem.Models.Entities;
using AssetCheckoutSystem.Repositories;
using Azure.Core;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace AssetCheckoutSystem.Services
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
            bool userExists = await _userRepository.GetByEmail(request.EmailAddress) != null;
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
            User? user = await _userRepository.GetByEmail(request.EmailAddress);

            if (user == null || !user.IsActive || user.PasswordHash != EncryptionHelper.ToSha256(request.Password))
            {
                return ServiceResult<AccessTokenDto>.Unauthorized();
            }

            AccessTokenDto tokenDto = _tokenService.CreateAccessToken(user);
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

        public async Task<ServiceResult<AccessTokenDto>> Refresh(string refreshToken, HttpResponse response)
        {
            User? user = await _userRepository.FindByRefreshTokenHash(EncryptionHelper.ToSha256(refreshToken));

            if (user == null || !user.IsActive) return ServiceResult<AccessTokenDto>.NotFound();

            bool refreshTokenExpired = user.RefreshTokenExpiresAt < DateTime.UtcNow;

            if (refreshTokenExpired) return ServiceResult<AccessTokenDto>.Unauthorized();

            AccessTokenDto tokenDto = _tokenService.CreateAccessToken(user);
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

        public async Task<ServiceResult<PasswordResetLink>> GeneratePasswordReset(Guid userId)
        {
            const int resetExpirationHours = 24;

            User? user = await _userRepository.GetById(userId);
            if (user == null || !user.IsActive) return ServiceResult<PasswordResetLink>.NotFound();

            var frontendURL = _configuration["FrontendURL"];
            var resetToken = EncryptionHelper.GenerateRandomSha256();
            var resetTokenExpiresAt = DateTime.UtcNow.AddHours(resetExpirationHours);

            await _userRepository.SaveResetToken(user, resetToken, resetTokenExpiresAt);

            var passwordResetLink = new PasswordResetLink()
            {
                Link = $"{frontendURL}/reset-password?resetToken={resetToken}&email={user.EmailAddress}",
                ExpiresAt = resetTokenExpiresAt
            };

            return ServiceResult<PasswordResetLink>.Success(passwordResetLink);
        }

        public async Task<ServiceResult> ResetPassword(ResetPasswordRequest request)
        {
            User? user = await _userRepository.GetByEmail(request.EmailAddress);
            if (user == null || !user.IsActive) return ServiceResult.Unauthorized();

            bool resetTokenValid = user.PasswordResetExpiresAt >= DateTime.UtcNow && 
                                user.PasswordResetTokenHash == EncryptionHelper.ToSha256(request.ResetToken);

            if (!resetTokenValid) return ServiceResult.Unauthorized();

            await _userRepository.SavePassword(user, request.Password);

            return ServiceResult.Success();
        }
    }
}
