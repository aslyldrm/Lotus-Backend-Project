using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryCategoryId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleCategoryCategoryId",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e846a82-7771-4776-a64a-02f2b2a5bb2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a194f28b-5955-41a3-b3e9-0400e3e907f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d68bf14a-5ca8-4411-8a8f-4a4d705eeacd");

            migrationBuilder.DropColumn(
                name: "ArticleCategoryCategoryId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryCategoryId",
                table: "Products",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryCategoryId",
                table: "Products",
                newName: "IX_Products_ProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "ProductCategories",
                newName: "ProductCategoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductCategories",
                newName: "ProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Articles",
                newName: "ArticleCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "ArticleCategories",
                newName: "ArticleCategoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ArticleCategories",
                newName: "ArticleCategoryId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f89c814-0dd4-4312-8dae-40b153df0809", null, "Doctor", "DOCTOR" },
                    { "a2d2bd23-6ab1-4b68-aa58-9610395ee664", null, "User", "USER" },
                    { "d8616e50-dc9a-46c1-b517-0f19d6aa7265", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "ArticleCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles");

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

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Products",
                newName: "ProductCategoryCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                newName: "IX_Products_ProductCategoryCategoryId");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryName",
                table: "ProductCategories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "ProductCategories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "ArticleCategoryId",
                table: "Articles",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "ArticleCategoryName",
                table: "ArticleCategories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "ArticleCategoryId",
                table: "ArticleCategories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ArticleCategoryCategoryId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e846a82-7771-4776-a64a-02f2b2a5bb2c", null, "User", "USER" },
                    { "a194f28b-5955-41a3-b3e9-0400e3e907f8", null, "Admin", "ADMIN" },
                    { "d68bf14a-5ca8-4411-8a8f-4a4d705eeacd", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryCategoryId",
                table: "Articles",
                column: "ArticleCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryCategoryId",
                table: "Articles",
                column: "ArticleCategoryCategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCategoryId",
                table: "Products",
                column: "ProductCategoryCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "CategoryId");
        }
    }
}
