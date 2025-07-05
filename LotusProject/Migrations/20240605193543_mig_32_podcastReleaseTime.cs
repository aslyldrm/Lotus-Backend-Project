using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_32_podcastReleaseTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseTime",
                table: "Podcasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DoctorCategoriesDoctorCategoryId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73217e5a-86b2-471a-9b11-a63c57681ada", null, "User", "USER" },
                    { "ba3d98bd-b633-4a2e-a17f-3a58e48bc702", null, "Doctor", "DOCTOR" },
                    { "d9dcb029-abea-4724-a309-c14189039a2e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorCategoriesDoctorCategoryId",
                table: "Doctors",
                column: "DoctorCategoriesDoctorCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorCategories_DoctorCategoriesDoctorCategoryId",
                table: "Doctors",
                column: "DoctorCategoriesDoctorCategoryId",
                principalTable: "DoctorCategories",
                principalColumn: "DoctorCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorCategories_DoctorCategoriesDoctorCategoryId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorCategoriesDoctorCategoryId",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73217e5a-86b2-471a-9b11-a63c57681ada");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba3d98bd-b633-4a2e-a17f-3a58e48bc702");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9dcb029-abea-4724-a309-c14189039a2e");

            migrationBuilder.DropColumn(
                name: "ReleaseTime",
                table: "Podcasts");

            migrationBuilder.DropColumn(
                name: "DoctorCategoriesDoctorCategoryId",
                table: "Doctors");

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
    }
}
