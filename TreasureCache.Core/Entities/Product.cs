namespace TreasureCache.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
    public decimal BasePrice { get; set; }
    public int Count { get; set; }
    public int Discount { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public int ProductFilesId { get; set; }
    public ProductFiles ProductFiles { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}