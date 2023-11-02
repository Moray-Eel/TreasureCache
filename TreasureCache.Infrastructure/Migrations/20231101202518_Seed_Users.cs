using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreasureCache.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            """
            INSERT INTO public."AspNetUsers" ("Id", "UserId", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount")
            VALUES
            (1, '53a18ecf-2e3c-4f93-9c77-cc9e61f4b975', 'John', 'JOHN', 'john@example.com', 'JOHN@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEOm2Xcm1UgKopm8Vjg/d0VmrZixZC12d5Wzq/tWGtIjUOuI+5hA72L+U/Cuy3HwF4Q==', 'SecurityStamp1', 'ConcurrencyStamp1', '123-456-7890', TRUE, TRUE, NULL, TRUE, 0),
            (2, '27ebc3d1-d3a6-45cc-95db-8c14c4d4b841', 'Alice', 'ALICE', 'alice@example.com', 'ALICE@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEKyUzLk7PzLrZuL0kOLvlC8bJ37RjX4N2qB4M8wifIhEvzwsvPw6+duMy0avR7V/7g==', 'SecurityStamp2', 'ConcurrencyStamp2', '987-654-3210', TRUE, TRUE, NULL, TRUE, 0),
            (3, '8a05d3c4-6f10-44e6-9f71-e14c9d4dbf4e', 'Michael', 'MICHAEL', 'michael@example.com', 'MICHAEL@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEG/zMKaTSw+Jz6PVF6XGpQvYsuvFCjRUCbEtnVzFw6C1k5mqLCA6ChzZXqfw2Pr05g==', 'SecurityStamp3', 'ConcurrencyStamp3', '555-123-7777', TRUE, TRUE, NULL, TRUE, 0),
            (4, 'b414e4a7-3f68-4cfd-9b23-22ee1d82464e', 'Emily', 'EMILY', 'emily@example.com', 'EMILY@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAECcrq3cMBlfVZlTYc/vM5VRXsCuhKRlH59qT9M/Xq/g7IDa1Nt5LFroNfT97AAmlRg==', 'SecurityStamp4', 'ConcurrencyStamp4', '111-222-3333', TRUE, TRUE, NULL, TRUE, 0),
            (5, '9f37133e-199d-4b05-92ce-c8c0bfe7d8d1', 'Daniel', 'DANIEL', 'daniel@example.com', 'DANIEL@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEC/cT8o+K7KDz7S9uWxrg6m7X8aCPiRJOY/ZXs9zIo/HnMtzsKbtrMng3zrXHplp8A==', 'SecurityStamp5', 'ConcurrencyStamp5', '999-888-7777', TRUE, TRUE, NULL, TRUE, 0),
            (6, '6b5f0b23-3f5b-45a5-9949-688c8e26a315', 'Olivia', 'OLIVIA', 'olivia@example.com', 'OLIVIA@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEOqkT5tMjC9osrmTm9vlSpt4OLu3J6q3nlNX+UaDoEz3s8RCNHb56RE9jKPMRpd5mg==', 'SecurityStamp6', 'ConcurrencyStamp6', '555-444-3333', TRUE, TRUE, NULL, TRUE, 0),
            (7, 'a23b176b-d700-40e4-a7c7-d38f43094a1c', 'William', 'WILLIAM', 'william@example.com', 'WILLIAM@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEM7Uf5AUJ2kHQ/0BrLb/jsofy7lcWLa13wD4ZV2NwZvczXGLgmj6F6Z8caB5W7q2Hg==', 'SecurityStamp7', 'ConcurrencyStamp7', '987-123-1111', TRUE, TRUE, NULL, TRUE, 0),
            (8, 'c6d3ab13-1e52-49b3-94e0-29a8a7d0d76c', 'Sophia', 'SOPHIA', 'sophia@example.com', 'SOPHIA@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEOj19dFqah6LvK65QDLpGYb6CzIJe8tcy2aAJnIBYwZlR+zP7OMa/rlk30zg3hTTNQ==', 'SecurityStamp8', 'ConcurrencyStamp8', '777-666-5555', TRUE, TRUE, NULL, TRUE, 0),
            (9, '16a3358a-8045-4f2f-9531-d4a1fbad2b2a', 'James', 'JAMES', 'james@example.com', 'JAMES@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEM1ZLsUg5uj1YRGKrg1UuG+DLhIG3hrM3cHeM1w/uj3Zh7XdJXyVQCVxxyDpeptfHg==', 'SecurityStamp9', 'ConcurrencyStamp9', '222-333-4444', TRUE, TRUE, NULL, TRUE, 0),
            (10, '41d844ef-0d78-4fc8-8db9-94f62c3e5e4b', 'Ava', 'AVA', 'ava@example.com', 'AVA@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEO8zgsSAtJ3I8VcIZvGlWkJj5KOm/Q0t8WfgfqWgk2Kv3EqjeLNGVJ9nm0S2Wf3Z9A==', 'SecurityStamp10', 'ConcurrencyStamp10', '999-333-5555', TRUE, TRUE, NULL, TRUE, 0),
            (11, '8f0b256e-dc46-4d5e-87c7-c097c4a09c6a', 'Benjamin', 'BENJAMIN', 'benjamin@example.com', 'BENJAMIN@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEGM6tV56NJ1MEXysbgwJZ/eFpywuaO/Tl9pGG3U7c4S13bd2VycS0fUa3P8fAZaYLw==', 'SecurityStamp11', 'ConcurrencyStamp11', '777-123-9999', TRUE, TRUE, NULL, TRUE, 0),
            (12, '6a8ee363-0f1e-46fc-9ebf-7a7856ad559f', 'Emma', 'EMMA', 'emma@example.com', 'EMMA@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEGB72MRuTTuXfN8SO83tu/Y9REXw6F67i8EgGLJ4hBVOxuizmep+iayXGcKdPO5Zdw==', 'SecurityStamp12', 'ConcurrencyStamp12', '123-999-1111', TRUE, TRUE, NULL, TRUE, 0),
            (13, 'f6b33d14-9423-4f13-98f8-3b3b4e3f4f6f', 'Liam', 'LIAM', 'liam@example.com', 'LIAM@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEG5LxBl+CD3oXUM3m88HUxjz+o+ZM/Ar+xgrNMLUBQv7V92hYUprv0gFf19e6X2gBw==', 'SecurityStamp13', 'ConcurrencyStamp13', '123-111-2222', TRUE, TRUE, NULL, TRUE, 0),
            (14, 'faa80a11-8207-4a05-bc1e-74aa8340fc4f', 'Charlotte', 'CHARLOTTE', 'charlotte@example.com', 'CHARLOTTE@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEC1YxdqZhJ2/7s5P96mZX7lt0DgNouT+p/4g3PwG/fqMGVANZ6O3cNwWfF8MYrTNUg==', 'SecurityStamp14', 'ConcurrencyStamp14', '79-888-7777', TRUE, TRUE, NULL, TRUE, 0),
            (15, 'c9b413d1-3a33-468e-b97e-81e13db2e0f5', 'Lucas', 'LUCAS', 'lucas@example.com', 'LUCAS@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEOUO58GtJb5ODZ0tL1mAlp/gAh1h4Aa4O0MG/5g0WMKrD3O9zIXn9P9NBSmF9K/GEw==', 'SecurityStamp15', 'ConcurrencyStamp15', '222-333-4444', TRUE, TRUE, NULL, TRUE, 0),
            (16, '206c98d2-ef8e-497c-a5d6-02cced0bcba8', 'Mia', 'MIA', 'mia@example.com', 'MIA@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEPEVDbfTUSv3qDjc4Tq+jzg5mUZnOy7N+7XQb9N2sJsm4pI5EPzUWYDVhtuj6smhMg==', 'SecurityStamp16', 'ConcurrencyStamp16', '94-123-1111', TRUE, TRUE, NULL, TRUE, 0),
            (17, '5f8aa8b6-8f1d-499b-aa19-64e836150bdf', 'Alexander', 'ALEXANDER', 'alexander@example.com', 'ALEXANDER@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEPKR2RsMkXHPnILt42XjW14P0KymFQOhL3R07zE5XeW+1KfUoRsO0NMAHHGf+wM2Fg==', 'SecurityStamp17', 'ConcurrencyStamp17', '61-888-9999', TRUE, TRUE, NULL, TRUE, 0),
            (18, '7d2c8ab2-515d-44a8-b3cd-e540f79e586b', 'Ella', 'ELLA', 'ella@example.com', 'ELLA@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEN/FaF2dnp9+qA3gQDzTGPN5OpA0+R/c2GZCYSaDRBYNOp2wvaT5cF02emKwSgBvRA==', 'SecurityStamp20', 'ConcurrencyStamp20', '111-222-3333', TRUE, TRUE, NULL, TRUE, 0),
            (19, 'cacdb3e1-733d-4006-a52a-4a8fbf99fdda', 'Henry', 'HENRY', 'henry@example.com', 'HENRY@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEOvSWKqxLW6oY5I/j6rXEz3tF8n6j4U7KzBWyKCGO/i5N8b6RxPNMw3a4MSWzK/qTg==', 'SecurityStamp18', 'ConcurrencyStamp18', '555-123-9999', TRUE, TRUE, NULL, TRUE, 0),
            (20, 'e8d7d2d1-6a97-4f80-bd0c-36cc12a2e7a5', 'Amelia', 'AMELIA', 'amelia@example.com', 'AMELIA@EXAMPLE.COM', TRUE, 'AQAAAAEAACcQAAAAEKFJtu5qr+MKLmmhwf7cYva9Oji2zJZ/Kx2QbrOQuPUjzR1BZymM81K2H2Y6KoZ1hg==', 'SecurityStamp19', 'ConcurrencyStamp19', '777-666-5555', TRUE, TRUE, NULL, TRUE, 0);
            """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
