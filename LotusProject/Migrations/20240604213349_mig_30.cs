using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b1b6059-db25-45d8-aa93-1d6198673d39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7063cde3-f2d7-4d18-9717-4ca9fc8b27f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de3ff843-1336-48a1-8cb7-13d7cbdeb404");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f0cbc16-bc0f-4a94-aebf-a849095994e1", null, "Admin", "ADMIN" },
                    { "6392cffd-6dd2-48e5-a99b-b360bc1d2e65", null, "Doctor", "DOCTOR" },
                    { "a20405be-2de6-4b96-9946-8cdb98b76076", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f0cbc16-bc0f-4a94-aebf-a849095994e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6392cffd-6dd2-48e5-a99b-b360bc1d2e65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a20405be-2de6-4b96-9946-8cdb98b76076");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b1b6059-db25-45d8-aa93-1d6198673d39", null, "User", "USER" },
                    { "7063cde3-f2d7-4d18-9717-4ca9fc8b27f4", null, "Admin", "ADMIN" },
                    { "de3ff843-1336-48a1-8cb7-13d7cbdeb404", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
