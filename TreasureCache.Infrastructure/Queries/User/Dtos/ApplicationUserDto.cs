namespace TreasureCache.Infrastructure.Queries.User.Dtos;

public record ApplicationUserDto(
    string Id,
    string? UserName,
    string? Email,
    bool EmailConfirmed,
    string? PhoneNumber,
    DomainUserDto DomainUser
    );