using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ArticleCategoryId",
                table: "Podcasts",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "178317a9-c3fa-41a7-a6b2-73a3d4cccb9c", null, "Doctor", "DOCTOR" },
                    { "88ac6254-cd5f-4b87-8db9-5523506b675c", null, "User", "USER" },
                    { "e6a6b78f-8f5c-4f25-82f0-ffd06814b75c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_ArticleCategoryId",
                table: "Podcasts",
                column: "ArticleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Podcasts_ArticleCategories_ArticleCategoryId",
                table: "Podcasts",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "ArticleCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Podcasts_ArticleCategories_ArticleCategoryId",
                table: "Podcasts");

            migrationBuilder.DropIndex(
                name: "IX_Podcasts_ArticleCategoryId",
                table: "Podcasts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "178317a9-c3fa-41a7-a6b2-73a3d4cccb9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ac6254-cd5f-4b87-8db9-5523506b675c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6a6b78f-8f5c-4f25-82f0-ffd06814b75c");

            migrationBuilder.DropColumn(
                name: "ArticleCategoryId",
                table: "Podcasts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34b335cc-f815-4d7e-a4bb-04d7ecfb058e", null, "Admin", "ADMIN" },
                    { "842fb273-1ebd-4b7d-8155-5414157ead25", null, "Doctor", "DOCTOR" },
                    { "d77c1afa-02a9-43d0-82d5-7e0a00ac5598", null, "User", "USER" }
                });
        }
    }
}
