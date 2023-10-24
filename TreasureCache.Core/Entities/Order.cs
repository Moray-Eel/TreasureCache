namespace TreasureCache.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid BuyerId { get; set; } 
    public DomainUser Buyer { get; set; } = null!;
}