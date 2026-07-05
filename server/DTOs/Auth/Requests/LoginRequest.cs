using System.ComponentModel.DataAnnotations;

namespace AssetCheckoutSystem.DTOs.Auth.Requests
{
    public class LoginRequest
    {
        [EmailAddress]
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
    }
}
