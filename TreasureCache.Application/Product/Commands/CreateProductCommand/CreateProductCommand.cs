using Microsoft.AspNetCore.Http;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands;

namespace TreasureCache.Application.Product.Commands.CreateProductCommand;

public record CreateProductCommand(string Name, string Description, decimal Price, int Discount, int Count, bool IsActive, 
    int CategoryId, byte[] LargeImage, byte[] SmallImage, byte[]? UserManual) : ICommand;
