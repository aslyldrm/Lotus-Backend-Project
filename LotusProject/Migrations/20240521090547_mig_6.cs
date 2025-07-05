using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "381a0a83-c9a1-446c-a5aa-fd610ab4efef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d35abcf-6fb5-4fe1-a6a0-002366dc635e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73bc92bd-47a3-4b6e-bc49-ce073926f3ae");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "381a0a83-c9a1-446c-a5aa-fd610ab4efef", null, "User", "USER" },
                    { "3d35abcf-6fb5-4fe1-a6a0-002366dc635e", null, "Doctor", "DOCTOR" },
                    { "73bc92bd-47a3-4b6e-bc49-ce073926f3ae", null, "Admin", "ADMIN" }
                });
        }
    }
}
