using TreasureCache.Infrastructure.Queries.User.Dtos;

namespace TreasureCache.Infrastructure.Queries.User.GetUserModal;

public record UserModalResponse(ApplicationUserDto User, List<ApplicationRoleDto> UserRoles, List<ApplicationRoleDto> Roles);