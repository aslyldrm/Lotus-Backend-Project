using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class nig_8_product_ownerIdchanging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a092e9e-3f4d-4858-8402-5a6e9c71f7fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae21ca73-f9fd-48d0-8466-6b54faa7fc2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d398df54-36e1-4124-84aa-0888975346cd");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a092e9e-3f4d-4858-8402-5a6e9c71f7fd", null, "Admin", "ADMIN" },
                    { "ae21ca73-f9fd-48d0-8466-6b54faa7fc2e", null, "User", "USER" },
                    { "d398df54-36e1-4124-84aa-0888975346cd", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
