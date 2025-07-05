using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f89c814-0dd4-4312-8dae-40b153df0809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2d2bd23-6ab1-4b68-aa58-9610395ee664");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8616e50-dc9a-46c1-b517-0f19d6aa7265");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "7f89c814-0dd4-4312-8dae-40b153df0809", null, "Doctor", "DOCTOR" },
                    { "a2d2bd23-6ab1-4b68-aa58-9610395ee664", null, "User", "USER" },
                    { "d8616e50-dc9a-46c1-b517-0f19d6aa7265", null, "Admin", "ADMIN" }
                });
        }
    }
}
