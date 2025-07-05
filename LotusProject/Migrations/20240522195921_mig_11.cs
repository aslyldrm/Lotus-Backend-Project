using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ReleaseDate",
                table: "Podcasts");

            migrationBuilder.RenameColumn(
                name: "AudioBase64",
                table: "Podcasts",
                newName: "Url");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0544f834-6346-499c-8c7b-ae0ced0be0bf", null, "Admin", "ADMIN" },
                    { "374d83d3-1c52-4a28-a1c7-70222a6df17b", null, "User", "USER" },
                    { "aef9d841-59d2-40aa-8c53-fb9cb360167b", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0544f834-6346-499c-8c7b-ae0ced0be0bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "374d83d3-1c52-4a28-a1c7-70222a6df17b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef9d841-59d2-40aa-8c53-fb9cb360167b");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Podcasts",
                newName: "AudioBase64");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Podcasts",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
