using Riok.Mapperly.Abstractions;
using TreasureCache.Infrastructure.Queries.Category.Dtos;
using TreasureCache.Infrastructure.Queries.Product.Dtos;
using Entities = TreasureCache.Core.Entities;
namespace TreasureCache.Infrastructure.Queries.Product.Mappers;

public static  class ProductMapper
{
    public static IQueryable<ProductWithCategoryDto> ProjectToDto(this IQueryable<Entities.Product> products)
    {
        return products.Select(p => new ProductWithCategoryDto(
            p.Id,
            p.Name,
            p.Description,
            p.BasePrice,
            p.Discount,
            p.Quantity,
            p.CreatedAt,
            p.IsActive,
            new ProductFilesDto(
                p.ProductFiles.Id, 
                p.ProductFiles.LargeImagePath, 
                p.ProductFiles.SmallImagePath, 
                p.ProductFiles.UserManualPath),
        new CategoryDto(
            p.Category.Id,
            p.Category.Name)
        ));
    }
    
    public static ProductDto ProjectToDto(this Entities.Product product)
    {
        return new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.BasePrice,
            product.Discount,
            product.Quantity,
            product.CreatedAt,
            product.IsActive,
            product.CategoryId,
            new ProductFilesDto(
                product.ProductFiles.Id,
                product.ProductFiles.LargeImagePath,
                product.ProductFiles.SmallImagePath,
                product.ProductFiles.UserManualPath));
    }
}