using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.ViewModels.Administration;

public class UsersModalViewModel
{
    public UpdateUserRequest Request { get; set; } = null!;
    public List<SelectListItem> Roles { get; set; } = null!;
}