using TreasureCache.Abstractions.Mediator.Interfaces.Commands;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries;

namespace TreasureCache.Abstractions.Mediator.Interfaces;

public interface IMediator
{
    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command);
    Task SendAsync(ICommand command);
    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query);
    Task SendAsync(IQuery query);
}