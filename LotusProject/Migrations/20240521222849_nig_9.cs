using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class nig_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c5a49c6-ceba-4c96-8457-d3a1e29075ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daf4a0af-d71f-402c-928f-d0d14e03a9c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f156f1d7-c3ed-46f7-b9fb-e2127cfd612b");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68c5f107-f222-4315-8a23-b8d2cc14387b", null, "Admin", "ADMIN" },
                    { "dbb69de9-ee14-44ff-b0d6-16a24d03fc57", null, "User", "USER" },
                    { "f6fe0e59-c722-40e3-8584-012e7fa5eb63", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68c5f107-f222-4315-8a23-b8d2cc14387b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbb69de9-ee14-44ff-b0d6-16a24d03fc57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6fe0e59-c722-40e3-8584-012e7fa5eb63");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "Category");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c5a49c6-ceba-4c96-8457-d3a1e29075ee", null, "Doctor", "DOCTOR" },
                    { "daf4a0af-d71f-402c-928f-d0d14e03a9c1", null, "User", "USER" },
                    { "f156f1d7-c3ed-46f7-b9fb-e2127cfd612b", null, "Admin", "ADMIN" }
                });
        }
    }
}
