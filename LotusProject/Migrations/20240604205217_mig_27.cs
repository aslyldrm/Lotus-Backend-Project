using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19b04e05-4404-4f72-8d63-50d5a082e96c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "328d43ba-2fa2-48dd-b621-0265c6866d04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3af4a258-f535-4b21-8b4b-a8cbf3146936");

            migrationBuilder.AddColumn<int>(
                name: "PodcastCategoryId",
                table: "Podcasts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArticleCategoryId = table.Column<int>(type: "int", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Doctors_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "ArticleCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34b335cc-f815-4d7e-a4bb-04d7ecfb058e", null, "Admin", "ADMIN" },
                    { "842fb273-1ebd-4b7d-8155-5414157ead25", null, "Doctor", "DOCTOR" },
                    { "d77c1afa-02a9-43d0-82d5-7e0a00ac5598", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ArticleCategoryId",
                table: "Doctors",
                column: "ArticleCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34b335cc-f815-4d7e-a4bb-04d7ecfb058e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "842fb273-1ebd-4b7d-8155-5414157ead25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d77c1afa-02a9-43d0-82d5-7e0a00ac5598");

            migrationBuilder.DropColumn(
                name: "PodcastCategoryId",
                table: "Podcasts");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19b04e05-4404-4f72-8d63-50d5a082e96c", null, "Admin", "ADMIN" },
                    { "328d43ba-2fa2-48dd-b621-0265c6866d04", null, "User", "USER" },
                    { "3af4a258-f535-4b21-8b4b-a8cbf3146936", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
