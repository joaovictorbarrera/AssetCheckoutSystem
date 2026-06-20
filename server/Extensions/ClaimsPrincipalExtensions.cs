using System.Security.Claims;

namespace AssetManagementSystem.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            return Guid.Parse(
                user.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }
    }
}
