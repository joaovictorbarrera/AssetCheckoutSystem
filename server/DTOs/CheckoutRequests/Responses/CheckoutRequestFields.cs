using System;
using System.Linq;
using System.Collections.Generic;
using AssetCheckoutSystem.Enums;
using AssetCheckoutSystem.Helpers;

namespace AssetCheckoutSystem.DTOs.CheckoutRequests.Responses
{
    public class CheckoutRequestFields
    {
        public List<string> Statuses { get; set; } = [.. Enum.GetNames(typeof(CheckoutRequestStatus)).Select(s => TextHelper.ToCamelCase(s))];
        public List<string> Types { get; set; } = [.. Enum.GetNames(typeof(CheckoutRequestType)).Select(t => TextHelper.ToCamelCase(t))];
    }
}
