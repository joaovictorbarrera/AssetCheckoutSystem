using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Models.Entities;
using System.Security.Claims;

namespace AssetCheckoutSystem.Helpers
{
    public class RolesHelper
    {
        public static bool IsAssetManager(Role role)
        {
            return role == Role.AssetManager || role == Role.Admin;
        }
    }
}
