using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            """ 
            INSERT INTO "Products" ("Name", "Description", "IsActive", "BasePrice", "Count", "Discount", "CreatedAt", "CategoryId", "ProductFilesId")
            VALUES
            ('Smartphone', 'High-end smartphone with advanced features', true, 799.99, 100, 10, NOW(), 3, 1),
            ('Laptop', 'Powerful laptop with fast processing and large storage', true, 1299.99, 50, 5, NOW(), 2, 2),
            ('Smart TV', 'Ultra HD Smart TV with built-in streaming apps', true, 899.99, 30, 0, NOW(), 1, 3),
            ('Men''s Suit', 'Elegant two-piece suit for formal occasions', true, 299.99, 20, 0, NOW(), 5, 4),
            ('Women''s Dress', 'Stylish evening dress for special events', true, 249.99, 25, 0, NOW(), 7, 5),
            ('T-Shirt', 'Comfortable cotton T-shirt for everyday wear', true, 19.99, 200, 0, NOW(), 8, 6),
            ('Sofa Set', 'Luxurious sofa set for your living room', true, 799.99, 10, 20, NOW(), 10, 7),
            ('Coffee Maker', 'Automatic coffee maker for brewing delicious coffee', true, 69.99, 30, 5, NOW(), 11, 8),
            ('Novel Book', 'Bestselling fiction novel for book enthusiasts', true, 14.99, 150, 0, NOW(), 13, 9),
            ('Fitness Tracker', 'Waterproof fitness tracker with heart rate monitor', true, 49.99, 100, 0, NOW(), 15, 10),
            ('Basketball', 'Official size basketball for sports enthusiasts', true, 29.99, 50, 0, NOW(), 17, 11),
            ('Car Battery', 'High-performance car battery for various vehicle models', true, 89.99, 15, 10, NOW(), 19, 12),
            ('Makeup Kit', 'Complete makeup kit for professional makeup artists', true, 129.99, 40, 8, NOW(), 23, 13),
            ('Board Game', 'Strategy board game for family entertainment', true, 39.99, 60, 0, NOW(), 26, 14),
            ('Vitamin C Supplement', 'High-quality Vitamin C supplement for immune support', true, 19.99, 100, 0, NOW(), 28, 15),
            ('Protein Snacks', 'Healthy protein snacks for fitness enthusiasts', true, 9.99, 200, 0, NOW(), 31, 16),
            ('Energy Drink', 'Refreshing energy drink for instant energy boost', true, 2.99, 500, 0, NOW(), 32, 17),
            ('Action Figure', 'Collectible action figure of popular movie character', true, 49.99, 30, 0, NOW(), 25, 18),
            ('Skincare Set', 'Complete skincare set for radiant and healthy skin', true, 79.99, 80, 10, NOW(), 22, 19),
            ('Car Accessories Bundle', 'Essential car accessories bundle for every driver', true, 129.99, 25, 5, NOW(), 20, 20);
            """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
