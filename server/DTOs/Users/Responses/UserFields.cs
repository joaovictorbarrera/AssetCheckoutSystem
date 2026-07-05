using System;
using System.Linq;
using System.Collections.Generic;
using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Helpers;

namespace AssetCheckoutSystem.DTOs.Users.Responses
{
    public class UserFields
    {
        public List<string> Roles { get; } = Enum.GetNames(typeof(Role))
            .Select(t => TextHelper.ToCamelCase(t))
            .ToList();
    }
}
