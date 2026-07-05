using AssetCheckoutSystem.Models.Entities;

namespace AssetCheckoutSystem.Extensions
{
    public static class HttpContextExtensions
    {
        public static User GetCurrentUser(
            this HttpContext context)
        {
            return (User) context.Items["User"]!;
        }
    }
}