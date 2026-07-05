namespace AssetManagementSystem.DTOs.Auth.Requests
{
    public class ResetPasswordRequest
    {
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
        public required string ResetToken { get; set; }
    }
}
