using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetCheckoutSystem.Migrations
{
    /// <inheritdoc />
    public partial class CorrectRequestDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-0000-0000-0000-000000000002"),
                column: "ApprovedAt",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-0000-0000-0000-000000000002"),
                column: "ApprovedAt",
                value: new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}
