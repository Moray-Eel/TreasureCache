using TreasureCache.Abstractions.Mediator.Interfaces.Commands;

namespace TreasureCache.Application.Payment.Commands.CheckOut;

public record CheckOutCommand(int ProductId, int Quantity) : ICommand<CheckoutResponse>;