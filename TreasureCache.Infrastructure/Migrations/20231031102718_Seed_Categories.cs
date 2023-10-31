using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            """
            INSERT INTO "Categories" 
            VALUES 
            (1, 'Electronics', true, null),
            (2, 'Laptops', true, 1),
            (3, 'Smartphones', true, 1),
            (4, 'Clothing', true, null),
            (5, 'Men''s Clothing', true, 4),
            (6, 'Women''s Clothing', true, 4),
            (7, 'Dresses', true, 6),
            (8, 'T-Shirts', true, 5),
            (9, 'Home and Garden', true, null),
            (10, 'Furniture', true, 9),
            (11, 'Kitchen Appliances', true, 9),
            (12, 'Books', true, null),
            (13, 'Fiction', true, 12),
            (14, 'Non-Fiction', true, 12),
            (15, 'Sports', true, null),
            (16, 'Football', true, 15),
            (17, 'Basketball', true, 15),
            (18, 'Automotive', true, null),
            (19, 'Car Parts', true, 18),
            (20, 'Car Accessories', true, 18),
            (21, 'Beauty', true, null),
            (22, 'Skincare', true, 21),
            (23, 'Makeup', true, 21),
            (24, 'Toys', true, null),
            (25, 'Action Figures', true, 24),
            (26, 'Board Games', true, 24),
            (27, 'Health', true, null),
            (28, 'Vitamins', true, 27),
            (29, 'Supplements', true, 27),
            (30, 'Food and Drink', true, null),
            (31, 'Snacks', true, 30),
            (32, 'Beverages', true, 30);
            """);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
