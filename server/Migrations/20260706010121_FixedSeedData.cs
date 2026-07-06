using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetCheckoutSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-0000-0000-0000-000000000002"),
                column: "Status",
                value: "Pending");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckoutRequests",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-0000-0000-0000-000000000002"),
                column: "Status",
                value: "Approved");
        }
    }
}
