using Microsoft.Extensions.DependencyInjection;
using TreasureCache.Abstractions.Mediator.Interfaces;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;

namespace TreasureCache.Abstractions.Mediator;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command)
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));
        var service = _serviceProvider.GetRequiredService(handlerType) as dynamic 
                      ?? throw new ArgumentNullException($"No handler found for {handlerType.Name}");

        return await service.HandleAsync((dynamic)command, new CancellationToken());
    }

    public async Task SendAsync(ICommand command)
    {
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
        var service = GetRegisteredHandler(handlerType);

        await service.HandleAsync((dynamic)command, new CancellationToken());
    }

    public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
        var service = GetRegisteredHandler(handlerType);
        return await service.HandleAsync((dynamic)query, new CancellationToken());
    }

    public async Task SendAsync(IQuery query)
    {
        var handlerType = typeof(IQueryHandler<>).MakeGenericType(query.GetType());
        var service = GetRegisteredHandler(handlerType);

        await service.HandleAsync((dynamic)query, new CancellationToken());
    }

    private dynamic GetRegisteredHandler(Type handlerType) => 
        _serviceProvider.GetRequiredService(handlerType) as dynamic 
        ?? throw new ArgumentNullException($"No handler found for {handlerType.Name}");
    }
