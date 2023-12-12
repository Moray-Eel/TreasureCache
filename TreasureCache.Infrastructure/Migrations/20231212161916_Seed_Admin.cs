using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApartmentNumber", "BuildingNumber", "City", "Country", "Street", "ZipCode" },
                values: new object[] { 1000, "admin", "admin", "admin", "admin", "admin", "admin" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1000);
        }
    }
}
