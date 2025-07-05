using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_2_ForumAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02003d23-48e1-4fcb-a422-384d72479a89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c6b37c2-bb57-4659-925f-ec61c821138e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dbc6b33-092f-40bd-b24e-2fafa52ebd4d");

            migrationBuilder.AddColumn<string>(
                name: "ProductLocation",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.QuestionId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37d39e2e-0bc5-400a-a2a6-765c613b799a", null, "Admin", "ADMIN" },
                    { "979853b3-48d2-4573-b210-bd7d65f2dcfc", null, "Doctor", "DOCTOR" },
                    { "d64c9a0b-7940-4aca-8d32-e5eb8216b58e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forums");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37d39e2e-0bc5-400a-a2a6-765c613b799a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "979853b3-48d2-4573-b210-bd7d65f2dcfc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d64c9a0b-7940-4aca-8d32-e5eb8216b58e");

            migrationBuilder.DropColumn(
                name: "ProductLocation",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02003d23-48e1-4fcb-a422-384d72479a89", null, "Admin", "ADMIN" },
                    { "6c6b37c2-bb57-4659-925f-ec61c821138e", null, "User", "USER" },
                    { "6dbc6b33-092f-40bd-b24e-2fafa52ebd4d", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
