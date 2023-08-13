using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedArchivedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedProducts_Categories_CategoryId",
                table: "ArchivedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedProducts_ProductDetails_ProductDetailId",
                table: "ArchivedProducts");

            migrationBuilder.DropIndex(
                name: "IX_ArchivedProducts_CategoryId",
                table: "ArchivedProducts");

            migrationBuilder.DropIndex(
                name: "IX_ArchivedProducts_ProductDetailId",
                table: "ArchivedProducts");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "ArchivedProducts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 21, 49, 19, 815, DateTimeKind.Local).AddTicks(8670), new DateTime(2023, 8, 13, 21, 49, 19, 815, DateTimeKind.Local).AddTicks(8686) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 21, 49, 19, 815, DateTimeKind.Local).AddTicks(8687), new DateTime(2023, 8, 13, 21, 49, 19, 815, DateTimeKind.Local).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 21, 49, 19, 815, DateTimeKind.Local).AddTicks(8689), new DateTime(2023, 8, 13, 21, 49, 19, 815, DateTimeKind.Local).AddTicks(8689) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductDetailId",
                table: "ArchivedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedProducts_Categories_CategoryId",
                table: "ArchivedProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedProducts_ProductDetails_ProductDetailId",
                table: "ArchivedProducts",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
