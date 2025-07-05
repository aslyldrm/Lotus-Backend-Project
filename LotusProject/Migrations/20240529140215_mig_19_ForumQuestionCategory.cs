using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_19_ForumQuestionCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76f360de-e609-4c8d-85b8-b8803f8c5dc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eb37662-dd09-4307-9b47-41331b35b2de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b2a4b80-1555-4f69-a6f6-1ac84df3d243");

            migrationBuilder.DropColumn(
                name: "SubjectContent",
                table: "Forums");

            migrationBuilder.RenameColumn(
                name: "SubjectTitle",
                table: "Forums",
                newName: "Question");

            migrationBuilder.AddColumn<int>(
                name: "ForumQuestionCategoryId",
                table: "Forums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ForumQuestionCategories",
                columns: table => new
                {
                    ForumQuestionCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumQuestionCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumQuestionCategories", x => x.ForumQuestionCategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08ed00be-add5-4838-bf9a-8a8ef04b4863", null, "Admin", "ADMIN" },
                    { "f429136d-7681-4bdf-a578-566a2bd08084", null, "Doctor", "DOCTOR" },
                    { "fe474934-d790-45f9-8184-44e49beb5ef1", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forums_ForumQuestionCategoryId",
                table: "Forums",
                column: "ForumQuestionCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_ForumQuestionCategories_ForumQuestionCategoryId",
                table: "Forums",
                column: "ForumQuestionCategoryId",
                principalTable: "ForumQuestionCategories",
                principalColumn: "ForumQuestionCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forums_ForumQuestionCategories_ForumQuestionCategoryId",
                table: "Forums");

            migrationBuilder.DropTable(
                name: "ForumQuestionCategories");

            migrationBuilder.DropIndex(
                name: "IX_Forums_ForumQuestionCategoryId",
                table: "Forums");

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

            migrationBuilder.DropColumn(
                name: "ForumQuestionCategoryId",
                table: "Forums");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Forums",
                newName: "SubjectTitle");

            migrationBuilder.AddColumn<string>(
                name: "SubjectContent",
                table: "Forums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76f360de-e609-4c8d-85b8-b8803f8c5dc3", null, "User", "USER" },
                    { "7eb37662-dd09-4307-9b47-41331b35b2de", null, "Admin", "ADMIN" },
                    { "9b2a4b80-1555-4f69-a6f6-1ac84df3d243", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
