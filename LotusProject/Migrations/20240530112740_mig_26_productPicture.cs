using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_26_productPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13ed0629-1eb8-476c-aa3d-e38acfaaa23b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19d0a5b2-e6f1-422f-b988-b6073653bc40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da9eca98-5e93-40a7-9c8c-b58ea0497f3a");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13ed0629-1eb8-476c-aa3d-e38acfaaa23b", null, "Doctor", "DOCTOR" },
                    { "19d0a5b2-e6f1-422f-b988-b6073653bc40", null, "Admin", "ADMIN" },
                    { "da9eca98-5e93-40a7-9c8c-b58ea0497f3a", null, "User", "USER" }
                });
        }
    }
}
