using TreasureCache.Abstractions.Mediator.Interfaces.Commands;
using TreasureCache.Application.Files.Dtos;

namespace TreasureCache.Application.Products.Commands.CreateProductCommand;

public record CreateProductCommand(string Name, string Description, decimal Price, int Discount, int Count, bool IsActive, 
    int CategoryId, FileDto LargeImage, FileDto SmallImage, FileDto? UserManual) : ICommand;
