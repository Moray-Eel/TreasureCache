using TreasureCache.Abstractions.Mediator.Interfaces.Commands;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Core.Entities;
using TreasureCache.Core.Interfaces.Repositories;

namespace TreasureCache.Application.Products.Commands.UpdateProductCommand;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task HandleAsync(UpdateProductCommand command, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetById(command.Id);
        product = UpdateProduct(product, command);

        await _productRepository.Update(product);
    }
    
    private Product UpdateProduct(Product product, UpdateProductCommand command)
    {
        product.Name = command.Name;
        product.Description = command.Description;
        product.IsActive = command.IsActive;
        product.BasePrice = command.Price;
        product.Quantity = command.Count;
        product.Discount = command.Discount;
        product.CategoryId = command.CategoryId;
        
        return product;
    }
}