using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.User.Dtos;

namespace TreasureCache.Presentation.ViewModels.Administration;

public class UsersPanelViewModel
{
    public PagedList<ApplicationUserDto> Users { get; set; }
    public List<ApplicationRoleDto> Roles { get; set; }
}