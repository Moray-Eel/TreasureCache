using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Addresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            """
            INSERT INTO "Addresses"
            VALUES 
            (1, 'USA', 'New York', 'Broadway St', '10001', '123', NULL),
            (2, 'Canada', 'Toronto', 'King St', 'M5V 1M3', '456', '789'),
            (3, 'UK', 'London', 'Oxford St', 'WC1A 1AA', '789', NULL),
            (4, 'Australia', 'Sydney', 'George St', '2000', '101', '202'),
            (5, 'France', 'Paris', 'Champs-Élysées', '75008', '505', NULL),
            (6, 'Germany', 'Berlin', 'Friedrichstrasse', '10117', '303', '404'),
            (7, 'Japan', 'Tokyo', 'Shibuya', '150-0002', '707', NULL),
            (8, 'Brazil', 'Rio de Janeiro', 'Copacabana', '22020-000', '606', '707'),
            (9, 'China', 'Beijing', 'Wangfujing St', '100006', '999', NULL),
            (10, 'India', 'Mumbai', 'Marine Drive', '400020', '111', '212'),
            (11, 'South Africa', 'Cape Town', 'Long St', '8001', '121', NULL),
            (12, 'Mexico', 'Mexico City', 'Paseo de la Reforma', '06500', '131', '232'),
            (13, 'Argentina', 'Buenos Aires', 'Avenida 9 de Julio', 'C1073ABA', '141', NULL),
            (14, 'Italy', 'Rome', 'Via del Corso', '00187', '151', '252'),
            (15, 'Spain', 'Barcelona', 'La Rambla', '08002', '161', NULL),
            (16, 'Russia', 'Moscow', 'Tverskaya St', '125009', '171', '272'),
            (17, 'Netherlands', 'Amsterdam', 'Dam Square', '1012 JW', '181', NULL),
            (18, 'Sweden', 'Stockholm', 'Drottninggatan', '111 21', '191', '292'),
            (19, 'Norway', 'Oslo', 'Karl Johans gate', '0154', '202', NULL),
            (20, 'Switzerland', 'Zurich', 'Bahnhofstrasse', '8001', '212', '313')
            """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
