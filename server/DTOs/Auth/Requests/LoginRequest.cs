using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.Auth.Requests
{
    public class LoginRequest
    {
        [EmailAddress]
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
    }
}
