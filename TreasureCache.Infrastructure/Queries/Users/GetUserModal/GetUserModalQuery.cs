using TreasureCache.Abstractions.Mediator.Interfaces.Queries;

namespace TreasureCache.Infrastructure.Queries.Users.GetUserModal;

public record GetUserModalQuery(string Id) : IQuery<UserModalResponse>;