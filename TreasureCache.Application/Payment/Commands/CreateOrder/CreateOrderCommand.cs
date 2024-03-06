using TreasureCache.Abstractions.Mediator.Interfaces.Commands;

namespace TreasureCache.Application.Payment.Commands.CreateOrder;

public record CreateOrderCommand(string sessionId) : ICommand;