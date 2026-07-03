using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AssetManagementSystem.Models.Entities;
using AssetManagementSystem.DTOs.Auth.Responses;
using AssetManagementSystem.DTOs.Auth.Internal;
using AssetManagementSystem.Helpers;

namespace AssetManagementSystem.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AccessTokenDto CreateToken(User user)
        {
            string jwtKey = _configuration["JwtKey"]
                ?? throw new Exception("JwtKey missing from configuration.");

            int expirationMinutes = _configuration.GetValue("AccessTokenExpirationMinutes", 15);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(expirationMinutes);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            AccessTokenDto tokenDto = new()
            {
                AuthorizationToken = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return tokenDto;
        }

        public Guid? GetUserIdFromToken(string token)
        {
            string jwtKey = _configuration["JwtKey"]
                ?? throw new Exception("JwtKey missing from configuration.");

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                ClaimsPrincipal principal = tokenHandler.ValidateToken(
                    token,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtKey))
                    },
                    out _);

                string? userId = principal.FindFirstValue(
                    ClaimTypes.NameIdentifier);

                return userId == null
                    ? null
                    : Guid.Parse(userId);
            }
            catch
            {
                return null;
            }
        }

        public RefreshTokenDto CreateRefreshToken()
        {
            DateTime ExpirationDate = DateTime.UtcNow.AddDays(_configuration.GetValue("RefreshTokenExpirationDays", 7));

            return new RefreshTokenDto
            {
                RefreshToken = EncryptionHelper.GenerateRandomSha256(),
                ExpiresAt = ExpirationDate
            };
        }
    }
}
