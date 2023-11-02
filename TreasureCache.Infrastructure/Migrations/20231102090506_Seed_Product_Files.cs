using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Product_Files : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            """ 
            INSERT INTO "ProductFiles"
            Values
            (1,'images/1021-800x400.jpg', 'images/536-200x300.jpg', NULL),
            (2,'images/241-400x600.jpg', 'images/536-200x300.jpg', NULL),
            (3,'images/252-500x500.jpg', 'images/237-200x300.jpg', NULL),
            (4,'images/252-500x500.jpg', 'mages/237-200x300.jpg', NULL),
            (5,'images/1021-800x400.jpg', 'images/536-200x300.jpg', NULL),
            (6,'images/1021-800x400.jpg', 'images/536-200x300.jpg', NULL),
            (7,'images/1021-800x400.jpg', 'images/536-200x300.jpg', NULL),
            (8,'images/241-400x600.jpg', 'images/536-200x300.jpg', NULL),
            (9,'images/252-500x500.jpg', 'images/536-200x300.jpg', NULL),
            (10,'images/1021-800x400.jpg', 'images/237-200x300.jpg', NULL),
            (11,'images/241-400x600.jpg', 'mages/237-200x300.jpg', NULL),
            (12,'images/241-400x600.jpg', 'mages/237-200x300.jpg', NULL),
            (13,'images/1021-800x400.jpg', 'images/536-200x300.jpg', NULL),
            (14,'images/241-400x600.jpg', 'images/536-200x300.jpg', NULL),
            (15,'images/252-500x500.jpg', 'images/237-200x300.jpg', NULL),
            (16,'images/252-500x500.jpg', 'mages/237-200x300.jpg', NULL),
            (17,'images/1021-800x400.jpg', 'images/536-200x300.jpg', NULL),
            (18,'images/1021-800x400.jpg', 'images/536-200x300.jpg', NULL),
            (19,'images/1021-800x400.jpg', 'images/536-200x300.jpg', NULL),
            (20,'images/241-400x600.jpg', 'images/536-200x300.jpg', NULL);
            """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
