using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "349ea1b2-e76c-4530-83e3-c3985c1ceec9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48833601-658b-4d2b-b0b9-869c2f01aad9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b12c7a72-282b-472c-89d4-bc4f9da16e2b");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "349ea1b2-e76c-4530-83e3-c3985c1ceec9", null, "Admin", "ADMIN" },
                    { "48833601-658b-4d2b-b0b9-869c2f01aad9", null, "User", "USER" },
                    { "b12c7a72-282b-472c-89d4-bc4f9da16e2b", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
