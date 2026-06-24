namespace AssetManagementSystem.DTOs.Auth
{
    public class TokenDto
    {
        public required string AuthorizationToken { get; set; }
        public required DateTime ExpirationDate { get; set; }
    }
}
