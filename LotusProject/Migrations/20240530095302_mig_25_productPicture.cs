using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_25_productPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "13ed0629-1eb8-476c-aa3d-e38acfaaa23b", null, "Doctor", "DOCTOR" },
                    { "19d0a5b2-e6f1-422f-b988-b6073653bc40", null, "Admin", "ADMIN" },
                    { "da9eca98-5e93-40a7-9c8c-b58ea0497f3a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13ed0629-1eb8-476c-aa3d-e38acfaaa23b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19d0a5b2-e6f1-422f-b988-b6073653bc40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da9eca98-5e93-40a7-9c8c-b58ea0497f3a");

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
    }
}
