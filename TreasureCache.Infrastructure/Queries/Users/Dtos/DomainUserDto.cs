namespace TreasureCache.Infrastructure.Queries.Users.Dtos;

public record DomainUserDto(
    Guid Id,
    string FirstName,
    string LastName,
    int PersonalDiscount,
    bool SignedForNewsletter
);