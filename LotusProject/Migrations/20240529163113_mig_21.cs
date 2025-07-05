using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0e6e2571-e802-44df-a2f5-3ba3f77e4534", null, "User", "USER" },
                    { "46e82a03-aa06-4449-88b1-4ac80fc333a8", null, "Admin", "ADMIN" },
                    { "71c31b23-069f-48c6-83ea-f36fc292887e", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e6e2571-e802-44df-a2f5-3ba3f77e4534");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e82a03-aa06-4449-88b1-4ac80fc333a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71c31b23-069f-48c6-83ea-f36fc292887e");

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
    }
}
