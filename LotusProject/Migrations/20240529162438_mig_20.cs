using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08ed00be-add5-4838-bf9a-8a8ef04b4863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f429136d-7681-4bdf-a578-566a2bd08084");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe474934-d790-45f9-8184-44e49beb5ef1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7035cc59-219a-4d68-a93a-cec67db473b5", null, "Doctor", "DOCTOR" },
                    { "c44d33ec-5cf2-4c22-b04a-42cc90a26ece", null, "Admin", "ADMIN" },
                    { "fc04e3e3-c02a-4e13-9603-829156c40554", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7035cc59-219a-4d68-a93a-cec67db473b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c44d33ec-5cf2-4c22-b04a-42cc90a26ece");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc04e3e3-c02a-4e13-9603-829156c40554");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08ed00be-add5-4838-bf9a-8a8ef04b4863", null, "Admin", "ADMIN" },
                    { "f429136d-7681-4bdf-a578-566a2bd08084", null, "Doctor", "DOCTOR" },
                    { "fe474934-d790-45f9-8184-44e49beb5ef1", null, "User", "USER" }
                });
        }
    }
}
