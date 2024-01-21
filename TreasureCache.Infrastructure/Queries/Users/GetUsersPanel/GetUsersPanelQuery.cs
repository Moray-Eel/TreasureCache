using TreasureCache.Abstractions.Mediator.Interfaces.Queries;
using TreasureCache.Abstractions.Paging;

namespace TreasureCache.Infrastructure.Queries.Users.GetUsersPanel;

public record GetUsersPanelQuery(int Page, int PageSize) : PagedRequest(Page, PageSize), IQuery<UsersPanelResponse>;