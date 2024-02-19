namespace TreasureCache.Core.Entities;

public class Cart
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset IsFinished { get; set; }
    public Guid OwnerId { get; set; }

    public DomainUser Owner { get; set; } = null!;
    // public ApplicationUser Owner { get; set; } = null!; // Referencing the ApplicationUser would break
    // the clean architecture rules - create another User class for domain layer and map it to the
    // persistence entity or configure this model with fluent API. In that case you won't be able 
    // to use include on Cart. Join manually 
}