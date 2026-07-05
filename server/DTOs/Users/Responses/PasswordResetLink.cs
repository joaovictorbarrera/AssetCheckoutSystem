namespace AssetCheckoutSystem.DTOs.Users.Responses
{
    public class PasswordResetLink
    {
        public required string Link { get; set; }
        public required DateTime ExpiresAt { get; set; }
    }
}
