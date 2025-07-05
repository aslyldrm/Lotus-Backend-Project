using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "9e846a82-7771-4776-a64a-02f2b2a5bb2c", null, "User", "USER" },
                    { "a194f28b-5955-41a3-b3e9-0400e3e907f8", null, "Admin", "ADMIN" },
                    { "d68bf14a-5ca8-4411-8a8f-4a4d705eeacd", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e846a82-7771-4776-a64a-02f2b2a5bb2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a194f28b-5955-41a3-b3e9-0400e3e907f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d68bf14a-5ca8-4411-8a8f-4a4d705eeacd");

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
    }
}
