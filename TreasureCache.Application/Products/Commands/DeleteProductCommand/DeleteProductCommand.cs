using TreasureCache.Abstractions.Mediator.Interfaces.Commands;

namespace TreasureCache.Application.Products.Commands.DeleteProductCommand;

public record DeleteProductCommand(int Id) : ICommand;