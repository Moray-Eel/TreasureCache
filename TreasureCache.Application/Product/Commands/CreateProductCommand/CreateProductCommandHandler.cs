using TreasureCache.Abstractions.Mediator.Interfaces.Commands.Handlers;
using TreasureCache.Core.Interfaces.Repositories;

namespace TreasureCache.Application.Product.Commands.CreateProductCommand;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task HandleAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}