namespace TreasureCache.Core.Entities;

public class Currency
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public decimal Rate { get; set; }
}