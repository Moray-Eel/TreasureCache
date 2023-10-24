namespace TreasureCache.Core.Entities;

public class ContactForm
{
    public int Id { get; set; }
    public string ContactReason { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public Guid SenderId { get; set; }
    public DomainUser Sender { get; set; } = null!;
}