using TreasureCache.Application.Files.Dtos;
using TreasureCache.Application.Products.Commands.CreateProductCommand;

namespace TreasureCache.Presentation.Requests;

public record UpdateProductRequest(
    int Id,
    string Name, 
    string Description, 
    decimal BasePrice, 
    int Discount, 
    int Count, 
    bool IsActive, 
    int CategoryId, 
    IFormFile LargeImage, 
    IFormFile SmallImage, 
    IFormFile? UserManual,
    string LargeImagePath,
    string SmallImagePath,
    string? UserManualPath
    );