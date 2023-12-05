using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Application.Files.Services.Interfaces;
using TreasureCache.Core.Entities;
using TreasureCache.Core.Interfaces.Repositories;

namespace TreasureCache.Application.Products.Commands.CreateProductCommand;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IFileHandlerService _fileHandlerService;
    public CreateProductCommandHandler(IProductRepository productRepository, IFileHandlerService fileHandlerService)
    {
        _productRepository = productRepository;
        _fileHandlerService = fileHandlerService;
    }
    public async Task HandleAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var (smallImagePath, largeImagePath, userManualPath) = 
            await _fileHandlerService
                .Handle(command.SmallImage, command.LargeImage, command.UserManual);

        var product = new Product()
        {
            CategoryId = command.CategoryId,
            Name = command.Name,
            Description = command.Description,
            IsActive = command.IsActive,
            BasePrice = command.Price,
            Count = command.Count,
            Discount = command.Discount,
            CreatedAt = DateTimeOffset.UtcNow,
            ProductFiles = new ProductFiles()
            {
                SmallImagePath = smallImagePath,
                LargeImagePath = largeImagePath,
                UserManualPath = userManualPath
            }
        };

        await _productRepository.Add(product);
    }
}