using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Queries.User.Dtos;

namespace TreasureCache.Infrastructure.Queries.User.GetUsersPanel;

public record UsersPanelResponse(PagedList<ApplicationUserDto> Users);