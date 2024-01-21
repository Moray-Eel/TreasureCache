using TreasureCache.Abstractions.Mediator.Interfaces.Commands;
using TreasureCache.Application.UserFiles.Dtos;

namespace TreasureCache.Application.Products.Commands.UpdateProductCommand;

public record UpdateProductCommand(int Id, string Name, string Description, decimal Price, int Discount, int Count, bool IsActive, 
    int CategoryId, FileDto LargeImage, FileDto SmallImage, FileDto? UserManual) : ICommand;