using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Users.Dtos;

namespace TreasureCache.Presentation.ViewModels.Administration;

public class UsersPanelViewModel
{
    public PagedList<ApplicationUserDto> Users { get; set; } = null!;
    public List<ApplicationRoleDto> Roles { get; set; } = null!;
}