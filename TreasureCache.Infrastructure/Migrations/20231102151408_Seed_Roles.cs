using Microsoft.EntityFrameworkCore.Migrations;
using TreasureCache.Infrastructure.Authentication.Constants;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            $"""
            INSERT INTO "AspNetRoles"
            VALUES 
            ('1', '{RoleNames.Admin}', '{NormalizedRoleNames.Admin}', '{Guid.NewGuid().ToString()}'),
            ('2', '{RoleNames.Moderator}', '{NormalizedRoleNames.Moderator}', '{Guid.NewGuid().ToString()}'),
            ('3', '{RoleNames.BaseUser}', '{NormalizedRoleNames.BaseUser}', '{Guid.NewGuid().ToString()}');
            """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
