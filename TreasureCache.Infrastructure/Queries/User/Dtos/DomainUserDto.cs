namespace TreasureCache.Infrastructure.Queries.User.Dtos;

public record DomainUserDto(
    Guid Id,
    string FirstName,
    string LastName,
    int PersonalDiscount,
    bool SignedForNewsletter
);