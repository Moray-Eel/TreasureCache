using TreasureCache.Abstractions.Mediator.Interfaces.Commands;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Application.UserFiles.Services.Interfaces;
using TreasureCache.Core.Entities;
using TreasureCache.Core.Interfaces.Repositories;

namespace TreasureCache.Application.Products.Commands.UpdateProductCommand;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IFileHandlerService _fileHandlerService;
    public UpdateProductCommandHandler(IProductRepository productRepository, IFileHandlerService fileHandlerService)
    {
        _productRepository = productRepository;
        _fileHandlerService = fileHandlerService;
    }
    public async Task HandleAsync(UpdateProductCommand command, CancellationToken cancellationToken = default)
    {
        var (smallImagePath, largeImagePath, userManualPath) = 
            await _fileHandlerService
                .Handle(command.SmallImage, command.LargeImage, command.UserManual);
        
        var product = await _productRepository
            .GetById(command.Id, cancellationToken);
        
        product.Name = command.Name;
        product.Description = command.Description;
        product.IsActive = command.IsActive;
        product.BasePrice = command.Price;
        product.Quantity = command.Count;
        product.Discount = command.Discount;
        product.CategoryId = command.CategoryId;
        product.ProductFiles.SmallImagePath = smallImagePath;
        product.ProductFiles.LargeImagePath = largeImagePath;
        product.ProductFiles.UserManualPath = userManualPath;
        
        await _productRepository.Update(product, 
            cancellationToken);
    }
}