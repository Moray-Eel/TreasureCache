namespace TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;

public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    public Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}

public interface IQueryHandler<TQuery> where TQuery : IQuery
{
    public Task HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}