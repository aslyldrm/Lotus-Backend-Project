using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ForumQuestionAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b8c9238-a55c-4234-b2ca-61bb1b4a9bd3", null, "Doctor", "DOCTOR" },
                    { "85ffd07d-49b6-46db-99ef-d4927a5c1bfe", null, "User", "USER" },
                    { "abf55a10-f9d5-4ed2-a079-eccfca6352f3", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b8c9238-a55c-4234-b2ca-61bb1b4a9bd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85ffd07d-49b6-46db-99ef-d4927a5c1bfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abf55a10-f9d5-4ed2-a079-eccfca6352f3");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ForumQuestionAnswers");

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
    }
}
