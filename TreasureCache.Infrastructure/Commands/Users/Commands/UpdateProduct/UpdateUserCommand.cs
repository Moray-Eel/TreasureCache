
using TreasureCache.Abstractions.Mediator.Interfaces.Commands;

namespace TreasureCache.Infrastructure.Commands.Users.Commands.UpdateProduct;

public record UpdateUserCommand(string Id, List<string> SelectedRoles, bool SignedUpForNewsletter, int PersonalDiscount) : ICommand;