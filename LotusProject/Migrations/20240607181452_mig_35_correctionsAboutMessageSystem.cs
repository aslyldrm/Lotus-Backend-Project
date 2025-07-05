using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_35_correctionsAboutMessageSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5cb187c-7780-4993-806d-998fdb0ab443");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5bc1dae-ec68-4e8c-90af-d4e87f49fb3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6f240d1-dcc6-4898-96f0-5af6df8bb8c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d9985898-a892-47e2-b439-5ac387e5bede", null, "Admin", "ADMIN" },
                    { "ddd93526-00d3-4f76-8282-312ca72882e5", null, "Doctor", "DOCTOR" },
                    { "e0359405-64f4-4d53-be3a-c4ab483085cb", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9985898-a892-47e2-b439-5ac387e5bede");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddd93526-00d3-4f76-8282-312ca72882e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0359405-64f4-4d53-be3a-c4ab483085cb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c5cb187c-7780-4993-806d-998fdb0ab443", null, "User", "USER" },
                    { "d5bc1dae-ec68-4e8c-90af-d4e87f49fb3a", null, "Doctor", "DOCTOR" },
                    { "f6f240d1-dcc6-4898-96f0-5af6df8bb8c3", null, "Admin", "ADMIN" }
                });
        }
    }
}
