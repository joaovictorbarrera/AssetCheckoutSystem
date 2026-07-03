using AssetManagementSystem.Models.Entities;
using System.Linq.Expressions;

namespace AssetManagementSystem.DTOs.CheckoutRequests.Projections
{
    public static class CheckoutRequestExpressions
    {
        public static Expression<Func<CheckoutRequest, CheckoutRequestDto>> ToDto =>
            r => new CheckoutRequestDto
            {
                Id = r.Id,
                RequestType = r.RequestType,
                RequestorId = r.RequestedByUserId,
                RequestorFirstName = r.RequestedByUser.FirstName,
                RequestorLastName = r.RequestedByUser.LastName,
                RequestorEmail = r.RequestedByUser.EmailAddress,
                Status = r.Status,
                AssignedAssetId = r.AssignedAssetId,
                IsArchived = r.IsArchived,
                CreatedAt = r.CreatedAt,
                AssetCategory = r.AssetCategory,
                AssignedAssetName = r.AssignedAsset == null ? null : r.AssignedAsset.Name,
                AssignedAssetTag = r.AssignedAsset == null ? null : r.AssignedAsset.AssetTag,
            };

        public static Expression<Func<CheckoutRequest, CheckoutRequestDetail>> ToDetail =>
            r => new CheckoutRequestDetail
            {
                Id = r.Id,
                RequestType = r.RequestType,
                RequestorId = r.RequestedByUserId,
                RequestorFirstName = r.RequestedByUser.FirstName,
                RequestorLastName = r.RequestedByUser.LastName,
                RequestorEmail = r.RequestedByUser.EmailAddress,
                Reason = r.Reason,
                Status = r.Status,
                ReviewerId = r.ReviewedByUserId,
                ReviewerFirstName = r.ReviewedByUser != null ? r.ReviewedByUser.FirstName : null,
                ReviewerLastName = r.ReviewedByUser != null ? r.ReviewedByUser.LastName : null,
                ReviewerEmail = r.ReviewedByUser != null ? r.ReviewedByUser.EmailAddress : null,
                AssetCategory = r.AssetCategory,
                AssignedAssetId = r.AssignedAssetId,
                AssignedAssetName = r.AssignedAsset == null ? null : r.AssignedAsset.Name,
                AssignedAssetTag = r.AssignedAsset == null ? null : r.AssignedAsset.AssetTag,
                ApprovedAt = r.ApprovedAt,
                RejectedAt = r.RejectedAt,
                FulfilledAt = r.FulfilledAt,
                ReturnedAt = r.ReturnedAt,
                UpdatedAt = r.UpdatedAt,
                CreatedAt = r.CreatedAt,
                IsArchived = r.IsArchived,
            };
    }
}
