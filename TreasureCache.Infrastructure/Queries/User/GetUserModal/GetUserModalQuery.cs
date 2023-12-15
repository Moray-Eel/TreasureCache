using TreasureCache.Abstractions.Mediator.Interfaces.Queries;

namespace TreasureCache.Infrastructure.Queries.User.GetUserModal;

public record GetUserModalQuery(string Id) : IQuery<UserModalResponse>;