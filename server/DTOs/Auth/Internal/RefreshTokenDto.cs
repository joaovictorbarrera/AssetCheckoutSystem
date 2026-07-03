namespace AssetManagementSystem.DTOs.Auth.Internal
{
    public class RefreshTokenDto
    {
        public required string RefreshToken { get; set; }
        public required DateTime ExpiresAt { get; set; }
    }
}
