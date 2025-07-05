using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12d92132-9ad5-4d7b-a48d-4c83d97c2d42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65306f24-2da7-476c-947f-70054de6470a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac2c1d2a-2b24-4530-b519-c9f46d30bd00");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76f360de-e609-4c8d-85b8-b8803f8c5dc3", null, "User", "USER" },
                    { "7eb37662-dd09-4307-9b47-41331b35b2de", null, "Admin", "ADMIN" },
                    { "9b2a4b80-1555-4f69-a6f6-1ac84df3d243", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76f360de-e609-4c8d-85b8-b8803f8c5dc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eb37662-dd09-4307-9b47-41331b35b2de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b2a4b80-1555-4f69-a6f6-1ac84df3d243");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12d92132-9ad5-4d7b-a48d-4c83d97c2d42", null, "User", "USER" },
                    { "65306f24-2da7-476c-947f-70054de6470a", null, "Doctor", "DOCTOR" },
                    { "ac2c1d2a-2b24-4530-b519-c9f46d30bd00", null, "Admin", "ADMIN" }
                });
        }
    }
}
