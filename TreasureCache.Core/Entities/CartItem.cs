namespace TreasureCache.Core.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int FinalPrice { get; set; }
    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;
}