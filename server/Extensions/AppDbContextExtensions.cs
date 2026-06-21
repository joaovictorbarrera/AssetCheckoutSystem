using AssetManagementSystem.Data;
using AssetManagementSystem.Models.Entities;

namespace AssetManagementSystem.Extensions
{
    public static class AppDbContextExtensions
    {
        public static void AddAssetHistory(
            this AppDbContext context,
            Guid assetId,
            Guid userId,
            string action,
            string? oldValue = null,
            string? newValue = null)
        {
            context.AssetHistories.Add(new AssetHistory
            {
                AssetId = assetId,
                UserId = userId,
                Action = action,
                OldValue = oldValue,
                NewValue = newValue
            });
        }
    }
}