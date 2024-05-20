using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class lastmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c48e8a4-ed5d-4319-9a4e-694cc6222cdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac500afb-633f-475b-8778-2848290af924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90fdf89-9601-4d05-baa4-e31ef556a2a9");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "4c48e8a4-ed5d-4319-9a4e-694cc6222cdc", null, "Guest", "GUEST" },
                    { "ac500afb-633f-475b-8778-2848290af924", null, "Manager", "MANAGER" },
                    { "d90fdf89-9601-4d05-baa4-e31ef556a2a9", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
