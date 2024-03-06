using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Infrastructure.Authentication.Constants;
using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.Persistence.Repositories;

namespace TreasureCache.Infrastructure.Commands.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
{
    private readonly ApplicationContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UpdateUserCommandHandler(ApplicationContext context,
        UserManager<ApplicationUser> userManager, IUserRepository userRepository)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task HandleAsync(UpdateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        await using var transaction =
            await _context.Database.BeginTransactionAsync(cancellationToken);
        {
            try
            {
                var user = await _userManager.Users
                               .Include(u => u.User)
                               .FirstOrDefaultAsync(u => u.Id == command.Id, cancellationToken)
                           ?? throw new NullReferenceException("User not found");

                if (await _userManager.IsInRoleAsync(user, RoleNames.Admin))
                    throw new InvalidOperationException("Cannot update admin user");

                await _context.UserRoles
                    .Where(ur => ur.UserId == user.Id)
                    .ExecuteDeleteAsync(cancellationToken);

                var roles = await _context.Roles
                                .Where(r => command.SelectedRoles.Contains(r.Id))
                                .Select(r => r.Name!)
                                .ToListAsync(cancellationToken)
                            ?? throw new NullReferenceException("Roles not found");

                await _userManager.AddToRolesAsync(user, roles);

                user.User.SignedForNewsletter = command.SignedUpForNewsletter;
                user.User.PersonalDiscount = command.PersonalDiscount;

                await _userManager.UpdateAsync(user);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}