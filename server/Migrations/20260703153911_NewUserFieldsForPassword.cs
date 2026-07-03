using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class NewUserFieldsForPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b7777777-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b8888888-0000-0000-0000-000000000001"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordChangedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetExpiresAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetTokenHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiresAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssetCategory",
                table: "CheckoutRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-0000-0000-0000-000000000001"),
                columns: new[] { "AssignedToUserId", "Status" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), "Assigned" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-0000-0000-0000-000000000002"),
                columns: new[] { "AssignedToUserId", "Status" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), "Assigned" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-0000-0000-0000-000000000002"),
                columns: new[] { "AssignedToUserId", "IsArchived", "Status" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), false, "Assigned" });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-0000-0000-0000-000000000003"),
                columns: new[] { "AssetCategory", "AssignedAssetId", "Reason", "RequestType", "RequestedByUserId" },
                values: new object[] { "SecurityKey", null, "MFA hardware key for new system rollout", 0, new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-0000-0000-0000-000000000001"),
                columns: new[] { "ApprovedAt", "AssetCategory", "CreatedAt", "Reason", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop", new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop for new project assignment", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-0000-0000-0000-000000000002"),
                columns: new[] { "ApprovedAt", "AssignedAssetId", "CreatedAt", "IsArchived", "Reason", "RequestType", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a2222222-0000-0000-0000-000000000002"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "Second monitor for home office, returning now", 1, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "RejectedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b5555555-0000-0000-0000-000000000001"),
                columns: new[] { "AssetCategory", "AssignedAssetId", "Reason" },
                values: new object[] { "Phone", new Guid("a3333333-0000-0000-0000-000000000001"), "Temporary phone for project sprint, returning now" });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b6666666-0000-0000-0000-000000000001"),
                columns: new[] { "AssetCategory", "AssignedAssetId", "CreatedAt", "Reason", "RejectedAt", "RequestType", "ReviewedByUserId", "Status", "UpdatedAt" },
                values: new object[] { "Headset", null, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Requested headset for calls, no longer needed", null, 0, null, "Cancelled", new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "CheckoutRequests",
                columns: new[] { "Id", "ApprovedAt", "AssetCategory", "AssignedAssetId", "CreatedAt", "FulfilledAt", "IsArchived", "Reason", "RejectedAt", "RequestType", "RequestedByUserId", "ReturnedAt", "ReviewedByUserId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b1111111-0000-0000-0000-000000000004"), null, "Monitor", new Guid("a2222222-0000-0000-0000-000000000001"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), null, false, "Returning second monitor, no longer needed", null, 1, new Guid("22222222-2222-2222-2222-222222222222"), null, null, "Pending", new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b3333333-0000-0000-0000-000000000002"), null, "SecurityKey", new Guid("a4444444-0000-0000-0000-000000000002"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, false, "No longer assigned to this project", new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("33333333-3333-3333-3333-333333333333"), null, new Guid("22222222-2222-2222-2222-222222222222"), "Rejected", new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b6666666-0000-0000-0000-000000000002"), null, "Monitor", new Guid("a2222222-0000-0000-0000-000000000001"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), null, false, "Requested to return monitor, changed mind", null, 1, new Guid("22222222-2222-2222-2222-222222222222"), null, null, "Cancelled", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "PasswordChangedAt", "PasswordHash", "PasswordResetExpiresAt", "PasswordResetTokenHash", "RefreshTokenExpiresAt", "RefreshTokenHash" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "PasswordChangedAt", "PasswordHash", "PasswordResetExpiresAt", "PasswordResetTokenHash", "RefreshTokenExpiresAt", "RefreshTokenHash" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "PasswordChangedAt", "PasswordHash", "PasswordResetExpiresAt", "PasswordResetTokenHash", "RefreshTokenExpiresAt", "RefreshTokenHash" },
                values: new object[] { null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b6666666-0000-0000-0000-000000000002"));

            migrationBuilder.DropColumn(
                name: "PasswordChangedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordResetExpiresAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiresAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenHash",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "AssetCategory",
                table: "CheckoutRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-0000-0000-0000-000000000001"),
                columns: new[] { "AssignedToUserId", "Status" },
                values: new object[] { null, "Available" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-0000-0000-0000-000000000002"),
                columns: new[] { "AssignedToUserId", "Status" },
                values: new object[] { null, "Available" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-0000-0000-0000-000000000002"),
                columns: new[] { "AssignedToUserId", "IsArchived", "Status" },
                values: new object[] { null, true, "Available" });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-0000-0000-0000-000000000003"),
                columns: new[] { "AssetCategory", "AssignedAssetId", "Reason", "RequestType", "RequestedByUserId" },
                values: new object[] { "Monitor", new Guid("a2222222-0000-0000-0000-000000000001"), "Returning second monitor, no longer needed", 1, new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-0000-0000-0000-000000000001"),
                columns: new[] { "ApprovedAt", "AssetCategory", "CreatedAt", "Reason", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), "SecurityKey", new DateTime(2025, 2, 1, 12, 0, 0, 0, DateTimeKind.Utc), "MFA hardware key for new system rollout", new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-0000-0000-0000-000000000002"),
                columns: new[] { "ApprovedAt", "AssignedAssetId", "CreatedAt", "IsArchived", "Reason", "RequestType", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 2, 2, 12, 0, 0, 0, DateTimeKind.Utc), true, "Second monitor requested for home office", 0, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "RejectedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 3, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b5555555-0000-0000-0000-000000000001"),
                columns: new[] { "AssetCategory", "AssignedAssetId", "Reason" },
                values: new object[] { "Monitor", new Guid("a2222222-0000-0000-0000-000000000003"), "Temporary monitor for project sprint, returning now" });

            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b6666666-0000-0000-0000-000000000001"),
                columns: new[] { "AssetCategory", "AssignedAssetId", "CreatedAt", "Reason", "RejectedAt", "RequestType", "ReviewedByUserId", "Status", "UpdatedAt" },
                values: new object[] { "SecurityKey", new Guid("a4444444-0000-0000-0000-000000000001"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Requesting to return security key, no longer assigned to this project", new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("22222222-2222-2222-2222-222222222222"), "Rejected", new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "CheckoutRequests",
                columns: new[] { "Id", "ApprovedAt", "AssetCategory", "AssignedAssetId", "CreatedAt", "FulfilledAt", "IsArchived", "Reason", "RejectedAt", "RequestType", "RequestedByUserId", "ReturnedAt", "ReviewedByUserId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b7777777-0000-0000-0000-000000000001"), null, "Monitor", new Guid("a2222222-0000-0000-0000-000000000002"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, false, "Requested to return monitor, changed mind", null, 1, new Guid("22222222-2222-2222-2222-222222222222"), null, null, "Cancelled", new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b8888888-0000-0000-0000-000000000001"), null, "Headset", null, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, false, "Requested headset for calls, no longer needed", null, 0, new Guid("33333333-3333-3333-3333-333333333333"), null, null, "Cancelled", new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }
    }
}
