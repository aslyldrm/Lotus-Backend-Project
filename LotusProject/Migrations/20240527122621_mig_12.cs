using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0544f834-6346-499c-8c7b-ae0ced0be0bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "374d83d3-1c52-4a28-a1c7-70222a6df17b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef9d841-59d2-40aa-8c53-fb9cb360167b");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "0544f834-6346-499c-8c7b-ae0ced0be0bf", null, "Admin", "ADMIN" },
                    { "374d83d3-1c52-4a28-a1c7-70222a6df17b", null, "User", "USER" },
                    { "aef9d841-59d2-40aa-8c53-fb9cb360167b", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
