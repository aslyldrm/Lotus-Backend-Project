using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_24_productPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b8c9238-a55c-4234-b2ca-61bb1b4a9bd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85ffd07d-49b6-46db-99ef-d4927a5c1bfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abf55a10-f9d5-4ed2-a079-eccfca6352f3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02208a3d-8572-450e-83c1-3d2c315eb08b", null, "User", "USER" },
                    { "4dfd2418-59d7-4de6-ac5e-bf30022feed4", null, "Admin", "ADMIN" },
                    { "f74e7413-bd83-4f12-a9f3-a4eb720e8cfe", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02208a3d-8572-450e-83c1-3d2c315eb08b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dfd2418-59d7-4de6-ac5e-bf30022feed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f74e7413-bd83-4f12-a9f3-a4eb720e8cfe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b8c9238-a55c-4234-b2ca-61bb1b4a9bd3", null, "Doctor", "DOCTOR" },
                    { "85ffd07d-49b6-46db-99ef-d4927a5c1bfe", null, "User", "USER" },
                    { "abf55a10-f9d5-4ed2-a079-eccfca6352f3", null, "Admin", "ADMIN" }
                });
        }
    }
}
