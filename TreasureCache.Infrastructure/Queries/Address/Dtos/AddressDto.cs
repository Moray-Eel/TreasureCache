namespace TreasureCache.Infrastructure.Queries.Address.Dtos;

public record AddressDto(
    int AddressId,
    string Street,
    string City,
    string ZipCode
);