using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Anonymous",
                table: "Forums",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d1b5ee6-d108-43f4-8504-8e759cb3fa65", null, "User", "USER" },
                    { "4d46f774-28ce-4557-b144-e70da828740e", null, "Admin", "ADMIN" },
                    { "6007add7-01d8-4042-a9f1-d5017f31baa9", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d1b5ee6-d108-43f4-8504-8e759cb3fa65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d46f774-28ce-4557-b144-e70da828740e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6007add7-01d8-4042-a9f1-d5017f31baa9");

            migrationBuilder.AlterColumn<bool>(
                name: "Anonymous",
                table: "Forums",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
