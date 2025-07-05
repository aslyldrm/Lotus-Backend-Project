using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_31_DoctorCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_ArticleCategories_ArticleCategoryId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ArticleCategoryId",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f0cbc16-bc0f-4a94-aebf-a849095994e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6392cffd-6dd2-48e5-a99b-b360bc1d2e65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a20405be-2de6-4b96-9946-8cdb98b76076");

            migrationBuilder.RenameColumn(
                name: "ArticleCategoryId",
                table: "Doctors",
                newName: "DoctorCategoryId");

            migrationBuilder.CreateTable(
                name: "DoctorCategories",
                columns: table => new
                {
                    DoctorCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorCategories", x => x.DoctorCategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11c78386-a6de-4d30-8ae9-aca2f05418dd", null, "User", "USER" },
                    { "20b89dff-49a1-4639-aa31-f1ce153a9f13", null, "Admin", "ADMIN" },
                    { "3a5bbf97-ef83-4fb9-a1e3-72e6d46dd080", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorCategories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11c78386-a6de-4d30-8ae9-aca2f05418dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20b89dff-49a1-4639-aa31-f1ce153a9f13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a5bbf97-ef83-4fb9-a1e3-72e6d46dd080");

            migrationBuilder.RenameColumn(
                name: "DoctorCategoryId",
                table: "Doctors",
                newName: "ArticleCategoryId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f0cbc16-bc0f-4a94-aebf-a849095994e1", null, "Admin", "ADMIN" },
                    { "6392cffd-6dd2-48e5-a99b-b360bc1d2e65", null, "Doctor", "DOCTOR" },
                    { "a20405be-2de6-4b96-9946-8cdb98b76076", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ArticleCategoryId",
                table: "Doctors",
                column: "ArticleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_ArticleCategories_ArticleCategoryId",
                table: "Doctors",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "ArticleCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
