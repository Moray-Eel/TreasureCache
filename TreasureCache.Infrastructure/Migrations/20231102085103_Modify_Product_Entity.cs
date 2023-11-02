using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Product_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFiles_Products_ProductId",
                table: "ProductFiles");

            migrationBuilder.DropIndex(
                name: "IX_ProductFiles_ProductId",
                table: "ProductFiles");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductFiles");

            migrationBuilder.AddColumn<int>(
                name: "ProductFilesId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserManualPath",
                table: "ProductFiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductFilesId",
                table: "Products",
                column: "ProductFilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductFiles_ProductFilesId",
                table: "Products",
                column: "ProductFilesId",
                principalTable: "ProductFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductFiles_ProductFilesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductFilesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductFilesId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "UserManualPath",
                table: "ProductFiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFiles_ProductId",
                table: "ProductFiles",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFiles_Products_ProductId",
                table: "ProductFiles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
