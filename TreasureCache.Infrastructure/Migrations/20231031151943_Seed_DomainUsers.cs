using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_DomainUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            """
            INSERT INTO "DomainUsers"
            VALUES
            ('53a18ecf-2e3c-4f93-9c77-cc9e61f4b975', 'John', 'Doe', 0, true, 1),
            ('27ebc3d1-d3a6-45cc-95db-8c14c4d4b841', 'Alice', 'Smith', 78, false, 2),
            ('8a05d3c4-6f10-44e6-9f71-e14c9d4dbf4e', 'Michael', 'Johnson', 0, true, 3),
            ('b414e4a7-3f68-4cfd-9b23-22ee1d82464e', 'Emily', 'Brown', 0, false, 4),
            ('9f37133e-199d-4b05-92ce-c8c0bfe7d8d1', 'Daniel', 'Miller', 0, true, 5),
            ('6b5f0b23-3f5b-45a5-9949-688c8e26a315', 'Olivia', 'Martinez', 67, false, 6),
            ('a23b176b-d700-40e4-a7c7-d38f43094a1c', 'William', 'Anderson', 0, true, 7),
            ('c6d3ab13-1e52-49b3-94e0-29a8a7d0d76c', 'Sophia', 'Lee', 88, false, 8),
            ('16a3358a-8045-4f2f-9531-d4a1fbad2b2a', 'James', 'Garcia', 73, true, 9),
            ('41d844ef-0d78-4fc8-8db9-94f62c3e5e4b', 'Ava', 'Wilson', 0, false, 10),
            ('8f0b256e-dc46-4d5e-87c7-c097c4a09c6a', 'Benjamin', 'Lopez', 56, true, 11),
            ('6a8ee363-0f1e-46fc-9ebf-7a7856ad559f', 'Emma', 'Hill', 64, false, 12),
            ('f6b33d14-9423-4f13-98f8-3b3b4e3f4f6f', 'Liam', 'Young', 0, true, 13),
            ('faa80a11-8207-4a05-bc1e-74aa8340fc4f', 'Charlotte', 'Scott', 79, false, 14),
            ('c9b413d1-3a33-468e-b97e-81e13db2e0f5', 'Lucas', 'Adams', 0, true, 15),
            ('206c98d2-ef8e-497c-a5d6-02cced0bcba8', 'Mia', 'Evans', 94, false, 16),
            ('5f8aa8b6-8f1d-499b-aa19-64e836150bdf', 'Alexander', 'Turner', 61, true, 17),
            ('7d2c8ab2-515d-44a8-b3cd-e540f79e586b', 'Grace', 'Baker', 0, false, 18),
            ('cacdb3e1-733d-4006-a52a-4a8fbf99fdda', 'Henry', 'Barnes', 89, true, 19),
            ('e8d7d2d1-6a97-4f80-bd0c-36cc12a2e7a5', 'Amelia', 'Cook', 0, false, 20)
            """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
