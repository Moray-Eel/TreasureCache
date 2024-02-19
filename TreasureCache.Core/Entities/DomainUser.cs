namespace TreasureCache.Core.Entities;

public class DomainUser
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int PersonalDiscount { get; set; }
    public bool SignedForNewsletter { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
}