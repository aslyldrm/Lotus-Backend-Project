using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_3_ForumAnswer_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ForumQuestionAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForumQuestionQuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumQuestionAnswers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_ForumQuestionAnswers_Forums_ForumQuestionQuestionId",
                        column: x => x.ForumQuestionQuestionId,
                        principalTable: "Forums",
                        principalColumn: "QuestionId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "997941a9-6a06-4c5f-911f-87fa3373abe0", null, "User", "USER" },
                    { "bf32a7bd-e322-4730-b5b9-0fae91b20171", null, "Admin", "ADMIN" },
                    { "cad4e98a-a697-499c-b8ee-08f8d776609b", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumQuestionAnswers_ForumQuestionQuestionId",
                table: "ForumQuestionAnswers",
                column: "ForumQuestionQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumQuestionAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "997941a9-6a06-4c5f-911f-87fa3373abe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf32a7bd-e322-4730-b5b9-0fae91b20171");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cad4e98a-a697-499c-b8ee-08f8d776609b");

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
    }
}
