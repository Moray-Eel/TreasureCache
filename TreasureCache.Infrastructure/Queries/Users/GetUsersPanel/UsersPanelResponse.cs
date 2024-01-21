using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.Users.Dtos;

namespace TreasureCache.Infrastructure.Queries.Users.GetUsersPanel;

public record UsersPanelResponse(PagedList<ApplicationUserDto> Users);