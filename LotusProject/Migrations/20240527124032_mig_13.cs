using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2997f329-718d-4ad5-9b53-d275064205e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41ce03a1-1027-4a41-bda4-c7d3e299a642");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "850ccbf9-a8be-4358-b32e-065662145201");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1aa9c053-b0de-4a2d-b833-b0abeca9a4b7", null, "User", "USER" },
                    { "2d76fb78-40d5-442a-b6aa-c8b377a10f49", null, "Doctor", "DOCTOR" },
                    { "d422f418-9e3a-4577-ba3b-7373181c99ec", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aa9c053-b0de-4a2d-b833-b0abeca9a4b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d76fb78-40d5-442a-b6aa-c8b377a10f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d422f418-9e3a-4577-ba3b-7373181c99ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2997f329-718d-4ad5-9b53-d275064205e4", null, "User", "USER" },
                    { "41ce03a1-1027-4a41-bda4-c7d3e299a642", null, "Doctor", "DOCTOR" },
                    { "850ccbf9-a8be-4358-b32e-065662145201", null, "Admin", "ADMIN" }
                });
        }
    }
}
