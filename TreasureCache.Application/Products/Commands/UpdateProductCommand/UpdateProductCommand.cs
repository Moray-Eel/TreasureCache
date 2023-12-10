using TreasureCache.Abstractions.Mediator.Interfaces.Commands;

namespace TreasureCache.Application.Products.Commands.UpdateProductCommand;

public record UpdateProductCommand(int Id, string Name, string Description, decimal Price, int Discount, int Count, bool IsActive, 
    int CategoryId) : ICommand;