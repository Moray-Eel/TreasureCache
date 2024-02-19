using Riok.Mapperly.Abstractions;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Queries.Users.Dtos;

namespace TreasureCache.Infrastructure.Queries.Users.Mappers;

[Mapper]
public static partial class ApplicationRoleMapper
{
    public static partial IQueryable<ApplicationRoleDto> ProjectToDto(
        this IQueryable<ApplicationRole> role);
}