using Microsoft.EntityFrameworkCore;
using TreasureCache.Abstractions.Mediator.Interfaces.Queries.Handlers;
using TreasureCache.Infrastructure.Persistence.Database;
using TreasureCache.Infrastructure.PriceLists;
using TreasureCache.Infrastructure.PriceLists.Creators;
using TreasureCache.Infrastructure.Queries.Products.Mappers;

namespace TreasureCache.Infrastructure.Queries.PriceLists.GetPriceList;

public class GetPriceListQueryHandler : IQueryHandler<GetPriceListQuery, Stream>
{
    private readonly ApplicationContext _context;

    public GetPriceListQueryHandler(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Stream> HandleAsync(GetPriceListQuery query,
        CancellationToken cancellationToken = default)
    {
        var products = await _context.Products
            .Where(p => p.CategoryId == query.CategoryId)
            .ProjectToDto()
            .ToListAsync(cancellationToken);

        var generator = GetCreator(query.DocumentType).Create();
        return generator.Generate(products);
    }

    private PriceListGeneratorCreator GetCreator(string documentType)
    {
        return documentType switch
        {
            "Docx" => new DocxPriceListGeneratorCreator(),
            "Excel" => new ExcelPriceListGeneratorCreator(),
            _ => new PdfPriceListGeneratorCreator(),
        };
    }
}