using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "5a38700b-af56-43b3-9673-1cec6ca9d0bc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a38700b-af56-43b3-9673-1cec6ca9d0bc");

            migrationBuilder.DeleteData(
                table: "DomainUsers",
                keyColumn: "Id",
                keyValue: new Guid("a923238c-1b83-41e7-b00f-66edfb33d2dd"));

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    AggregatePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DomainUsers",
                columns: new[] { "Id", "AddressId", "FirstName", "LastName", "PersonalDiscount", "SignedForNewsletter" },
                values: new object[] { new Guid("87bc7717-f196-4d1f-9fbd-628fd7ba5b2d"), 1000, "admin", "admin", 0, false });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "216c1a70-31f1-4417-8b67-e7653dc94033", 0, "7ae7ac17-2172-422f-84c4-51af673793fc", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKMdgvio58JeRIvj9JD/dXvCquTCnAvUvHK1HUP2wh4ZNAMZVbrpnTlto+gsnhFQvA==", null, false, "6688fcf9-cb5e-4cd2-b112-5b1e08cece55", false, new Guid("87bc7717-f196-4d1f-9fbd-628fd7ba5b2d"), "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "216c1a70-31f1-4417-8b67-e7653dc94033" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "216c1a70-31f1-4417-8b67-e7653dc94033" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "216c1a70-31f1-4417-8b67-e7653dc94033");

            migrationBuilder.DeleteData(
                table: "DomainUsers",
                keyColumn: "Id",
                keyValue: new Guid("87bc7717-f196-4d1f-9fbd-628fd7ba5b2d"));

            migrationBuilder.InsertData(
                table: "DomainUsers",
                columns: new[] { "Id", "AddressId", "FirstName", "LastName", "PersonalDiscount", "SignedForNewsletter" },
                values: new object[] { new Guid("a923238c-1b83-41e7-b00f-66edfb33d2dd"), 1000, "admin", "admin", 0, false });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "5a38700b-af56-43b3-9673-1cec6ca9d0bc", 0, "43299b97-45c8-419a-a429-2a917d7ff3c1", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEBB2Ux8tfGe6SLXYNBlAvnfK47SWbYelYiym3VP7ljQWGwMeBVvvqT9FxhUQ7UJGlg==", null, false, "900ebf70-ad01-44e2-b23c-423711b2db1e", false, new Guid("a923238c-1b83-41e7-b00f-66edfb33d2dd"), "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "5a38700b-af56-43b3-9673-1cec6ca9d0bc" });
        }
    }
}
