using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Infrastructure.Authentication.Constants;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Queries.User.Mappers;

namespace TreasureCache.Infrastructure.Queries.User.GetUserModal;

public class GetUserModalHandler : IQueryHandler<GetUserModalQuery, UserModalResponse>
{
    private readonly ApplicationContext _context;

    public GetUserModalHandler(ApplicationContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
    }

    public async Task<UserModalResponse> HandleAsync(GetUserModalQuery query, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
        
        var userDto = user?.ProjectToDto() 
                      ?? throw new NullReferenceException("User not found");

        var roles = await _context.Roles
            .Where(r => r.Name != RoleNames.Admin)
            .ProjectToDto()
            .ToListAsync(cancellationToken);
        
        var userRoles = _context.UserRoles
            .Where(ur => ur.UserId == user.Id)
            .Join(_context.Roles,
                userRole => userRole.RoleId,
                role => role.Id,
                (userRole, role) => role);
        
        if(await userRoles.AnyAsync(x => x.Name == RoleNames.Admin, cancellationToken))
        {
            throw new InvalidOperationException("Cannot edit admin user");
        }

        var userRolesDtos = await userRoles
            .ProjectToDto()
            .ToListAsync(cancellationToken);
        
        var response = new UserModalResponse(userDto, userRolesDtos, roles);

        return response;
    }
}