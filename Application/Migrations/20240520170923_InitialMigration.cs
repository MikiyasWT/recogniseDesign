using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3237d1af-7f4b-4b48-a673-5e475a9ea9aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c0e647a-8aeb-4c68-b2cc-fdbfcb2526ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e62abe24-6c64-4582-8ac8-30bef0d2bea9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37ecebcb-8c0e-4840-9b34-d9cbf314506b", null, "Administrator", "ADMINISTRATOR" },
                    { "7e55a607-1556-4f16-8961-d7eb3906c4e6", null, "Guest", "GUEST" },
                    { "c6d3f319-fd21-4d8c-8208-271e2c32045d", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37ecebcb-8c0e-4840-9b34-d9cbf314506b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e55a607-1556-4f16-8961-d7eb3906c4e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6d3f319-fd21-4d8c-8208-271e2c32045d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3237d1af-7f4b-4b48-a673-5e475a9ea9aa", null, "Manager", "MANAGER" },
                    { "9c0e647a-8aeb-4c68-b2cc-fdbfcb2526ea", null, "Guest", "GUEST" },
                    { "e62abe24-6c64-4582-8ac8-30bef0d2bea9", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
