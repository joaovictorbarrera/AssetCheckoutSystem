using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetCheckoutSystem.Migrations
{
    /// <inheritdoc />
    public partial class AssetHistorySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AssetHistories",
                columns: new[] { "Id", "Action", "AssetId", "CreatedAt", "NewValue", "OldValue", "UserId" },
                values: new object[,]
                {
                    { new Guid("c1111111-0000-0000-0000-000000000001"), "Created Asset", new Guid("a1111111-0000-0000-0000-000000000001"), new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c1111111-0000-0000-0000-000000000002"), "Updated Asset Status", new Guid("a1111111-0000-0000-0000-000000000001"), new DateTime(2025, 1, 10, 10, 0, 0, 0, DateTimeKind.Utc), "Assigned", "Available", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c1111111-0000-0000-0000-000000000003"), "Assigned Asset to employee@test.com", new Guid("a1111111-0000-0000-0000-000000000001"), new DateTime(2025, 1, 10, 10, 0, 1, 0, DateTimeKind.Utc), null, null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c1111111-0000-0000-0000-000000000004"), "Created Asset", new Guid("a1111111-0000-0000-0000-000000000002"), new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c1111111-0000-0000-0000-000000000005"), "Created Asset", new Guid("a1111111-0000-0000-0000-000000000003"), new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c1111111-0000-0000-0000-000000000006"), "Updated Asset Status", new Guid("a1111111-0000-0000-0000-000000000003"), new DateTime(2025, 1, 3, 9, 1, 0, 0, DateTimeKind.Utc), "Maintenance", "Available", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000001"), "Created Asset", new Guid("a2222222-0000-0000-0000-000000000001"), new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000002"), "Updated Asset Status", new Guid("a2222222-0000-0000-0000-000000000001"), new DateTime(2025, 1, 4, 9, 1, 0, 0, DateTimeKind.Utc), "Assigned", "Available", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000003"), "Assigned Asset to manager@test.com", new Guid("a2222222-0000-0000-0000-000000000001"), new DateTime(2025, 1, 4, 9, 1, 1, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000004"), "Created Asset", new Guid("a2222222-0000-0000-0000-000000000002"), new DateTime(2025, 1, 4, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000005"), "Updated Asset Status", new Guid("a2222222-0000-0000-0000-000000000002"), new DateTime(2025, 1, 4, 9, 2, 0, 0, DateTimeKind.Utc), "Assigned", "Available", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000006"), "Assigned Asset to employee@test.com", new Guid("a2222222-0000-0000-0000-000000000002"), new DateTime(2025, 1, 4, 9, 2, 1, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000007"), "Created Asset", new Guid("a2222222-0000-0000-0000-000000000003"), new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000008"), "Updated Asset Status", new Guid("a2222222-0000-0000-0000-000000000003"), new DateTime(2025, 1, 5, 9, 1, 0, 0, DateTimeKind.Utc), "Retired", "Available", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c2222222-0000-0000-0000-000000000009"), "Archived Asset", new Guid("a2222222-0000-0000-0000-000000000003"), new DateTime(2025, 1, 5, 9, 1, 1, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c3333333-0000-0000-0000-000000000001"), "Created Asset", new Guid("a3333333-0000-0000-0000-000000000001"), new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c3333333-0000-0000-0000-000000000002"), "Updated Asset Status", new Guid("a3333333-0000-0000-0000-000000000001"), new DateTime(2025, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), "Assigned", "Available", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c3333333-0000-0000-0000-000000000003"), "Assigned Asset to employee@test.com", new Guid("a3333333-0000-0000-0000-000000000001"), new DateTime(2025, 1, 15, 10, 0, 1, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c3333333-0000-0000-0000-000000000004"), "Asset marked as Returned", new Guid("a3333333-0000-0000-0000-000000000001"), new DateTime(2025, 1, 20, 10, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c3333333-0000-0000-0000-000000000005"), "Unassigned Asset from employee@test.com", new Guid("a3333333-0000-0000-0000-000000000001"), new DateTime(2025, 1, 20, 10, 0, 1, 0, DateTimeKind.Utc), null, null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c3333333-0000-0000-0000-000000000006"), "Updated Asset Status", new Guid("a3333333-0000-0000-0000-000000000001"), new DateTime(2025, 1, 20, 10, 0, 2, 0, DateTimeKind.Utc), "Available", "Assigned", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c3333333-0000-0000-0000-000000000007"), "Created Asset", new Guid("a3333333-0000-0000-0000-000000000002"), new DateTime(2025, 1, 6, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c4444444-0000-0000-0000-000000000001"), "Created Asset", new Guid("a4444444-0000-0000-0000-000000000001"), new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c4444444-0000-0000-0000-000000000002"), "Created Asset", new Guid("a4444444-0000-0000-0000-000000000002"), new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Utc), null, null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c4444444-0000-0000-0000-000000000003"), "Updated Asset Status", new Guid("a4444444-0000-0000-0000-000000000002"), new DateTime(2025, 1, 7, 9, 1, 0, 0, DateTimeKind.Utc), "Assigned", "Available", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c4444444-0000-0000-0000-000000000004"), "Assigned Asset to employee@test.com", new Guid("a4444444-0000-0000-0000-000000000002"), new DateTime(2025, 1, 7, 9, 1, 1, 0, DateTimeKind.Utc), null, null, new Guid("22222222-2222-2222-2222-222222222222") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "AssetHistories",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-0000-0000-0000-000000000004"));
        }
    }
}
