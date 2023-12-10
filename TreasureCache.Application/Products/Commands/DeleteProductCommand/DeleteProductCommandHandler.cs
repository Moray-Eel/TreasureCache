using TreasureCache.Abstractions.Mediator.Interfaces.Commands;
using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Application.Files.Services.Interfaces;
using TreasureCache.Core.Entities;
using TreasureCache.Core.Interfaces.Repositories;

namespace TreasureCache.Application.Products.Commands.DeleteProductCommand;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetById(command.Id);
        await _productRepository.Remove(product);
    }
}