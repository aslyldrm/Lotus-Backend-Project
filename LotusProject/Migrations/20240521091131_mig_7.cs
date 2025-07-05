using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dae4bdd-60dc-45ff-a07a-e6785c648a9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c865092e-4bac-4ab8-996b-3d34f23b3280");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff6b3dbb-addb-4a9e-80a9-3d2dba3a1eb7");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a092e9e-3f4d-4858-8402-5a6e9c71f7fd", null, "Admin", "ADMIN" },
                    { "ae21ca73-f9fd-48d0-8466-6b54faa7fc2e", null, "User", "USER" },
                    { "d398df54-36e1-4124-84aa-0888975346cd", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a092e9e-3f4d-4858-8402-5a6e9c71f7fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae21ca73-f9fd-48d0-8466-6b54faa7fc2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d398df54-36e1-4124-84aa-0888975346cd");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8dae4bdd-60dc-45ff-a07a-e6785c648a9a", null, "User", "USER" },
                    { "c865092e-4bac-4ab8-996b-3d34f23b3280", null, "Doctor", "DOCTOR" },
                    { "ff6b3dbb-addb-4a9e-80a9-3d2dba3a1eb7", null, "Admin", "ADMIN" }
                });
        }
    }
}
