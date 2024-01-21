using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Abstractions.Paging;
using TreasureCache.Infrastructure.Authentication.Constants;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.Users.Dtos;
using TreasureCache.Infrastructure.Queries.Users.Mappers;

namespace TreasureCache.Infrastructure.Queries.Users.GetUsersPanel;

public class GetUsersPanelHandler : IQueryHandler<GetUsersPanelQuery, UsersPanelResponse>
{
    private readonly ApplicationContext _context;
    public GetUsersPanelHandler(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<UsersPanelResponse> HandleAsync(GetUsersPanelQuery panelQuery, CancellationToken cancellationToken = default)
    {
        var adminId = (await _context.Roles
            .FirstOrDefaultAsync(x => x.Name == RoleNames.Admin, cancellationToken)
            )?.Id ?? throw new NullReferenceException("Admin role not found");
        
        var noAdminUsersIds = _context.UserRoles
            .Where(x => x.RoleId != adminId)
            .Distinct()
            .Select(x => x.UserId);

        var noAdminUsers = _context.Users
            .Where(x => noAdminUsersIds.Contains(x.Id))
            .ProjectToDto();
            
        var users = await PagedList<ApplicationUserDto>
            .ToPagedList(noAdminUsers, panelQuery.Page, panelQuery.PageSize, cancellationToken);

        return new UsersPanelResponse(users);
    }
}