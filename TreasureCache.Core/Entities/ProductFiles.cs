namespace TreasureCache.Core.Entities;

public class ProductFiles
{
    public int Id { get; set; }
    public string LargeImagePath { get; set; } = null!;
    public string SmallImagePath { get; set; } = null!;
    public string? UserManualPath { get; set; } = null!;
}