using TreasureCache.Infrastructure.Queries.Users.Dtos;

namespace TreasureCache.Infrastructure.Queries.Users.GetUserModal;

public record UserModalResponse(
    ApplicationUserDto User,
    List<ApplicationRoleDto> UserRoles,
    List<ApplicationRoleDto> Roles);