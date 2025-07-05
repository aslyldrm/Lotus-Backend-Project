using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_10_podcast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68c5f107-f222-4315-8a23-b8d2cc14387b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbb69de9-ee14-44ff-b0d6-16a24d03fc57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6fe0e59-c722-40e3-8584-012e7fa5eb63");

            migrationBuilder.AddColumn<bool>(
                name: "Anonymous",
                table: "Forums",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Forums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Podcasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Writers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6879be91-b10d-456b-93f7-1ce8c28a45fb", null, "Admin", "ADMIN" },
                    { "d43a414b-a7f1-4276-b93a-928959907eff", null, "User", "USER" },
                    { "e2b248a4-6c9c-4bb7-88c4-49addf881dd3", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Podcasts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6879be91-b10d-456b-93f7-1ce8c28a45fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d43a414b-a7f1-4276-b93a-928959907eff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2b248a4-6c9c-4bb7-88c4-49addf881dd3");

            migrationBuilder.DropColumn(
                name: "Anonymous",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Forums");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68c5f107-f222-4315-8a23-b8d2cc14387b", null, "Admin", "ADMIN" },
                    { "dbb69de9-ee14-44ff-b0d6-16a24d03fc57", null, "User", "USER" },
                    { "f6fe0e59-c722-40e3-8584-012e7fa5eb63", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
