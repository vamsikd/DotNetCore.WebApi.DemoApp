using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedOn", "Description", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "ELECT", new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1782), "Electronic products", "Electronics", new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1798) },
                    { 2, "BEAUT", new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1800), "Beauty cosmetics", "Beauty", new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1800) },
                    { 3, "FASHN", new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1801), "Fashion apperal", "Fashion", new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1802) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
