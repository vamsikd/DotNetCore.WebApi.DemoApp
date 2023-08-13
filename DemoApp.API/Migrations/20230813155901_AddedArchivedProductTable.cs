using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedArchivedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchivedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivedProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchivedProducts_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 21, 29, 0, 909, DateTimeKind.Local).AddTicks(9531), new DateTime(2023, 8, 13, 21, 29, 0, 909, DateTimeKind.Local).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 21, 29, 0, 909, DateTimeKind.Local).AddTicks(9544), new DateTime(2023, 8, 13, 21, 29, 0, 909, DateTimeKind.Local).AddTicks(9544) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 21, 29, 0, 909, DateTimeKind.Local).AddTicks(9545), new DateTime(2023, 8, 13, 21, 29, 0, 909, DateTimeKind.Local).AddTicks(9546) });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedProducts_CategoryId",
                table: "ArchivedProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedProducts_ProductDetailId",
                table: "ArchivedProducts",
                column: "ProductDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivedProducts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1782), new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1798) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1800), new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1801), new DateTime(2023, 8, 12, 23, 47, 57, 348, DateTimeKind.Local).AddTicks(1802) });
        }
    }
}
