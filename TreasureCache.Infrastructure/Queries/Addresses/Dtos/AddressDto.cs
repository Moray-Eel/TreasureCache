namespace TreasureCache.Infrastructure.Queries.Addresses.Dtos;

public record AddressDto(
    int AddressId,
    string Street,
    string City,
    string ZipCode
);