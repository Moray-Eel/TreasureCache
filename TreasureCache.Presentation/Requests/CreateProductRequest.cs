using System.ComponentModel.DataAnnotations;

namespace TreasureCache.Presentation.Requests;


public record CreateProductRequest([Required]string Name, string Description, decimal Price, int Discount, int Count, bool IsActive, 
    int CategoryId, IFormFile LargeImage, IFormFile SmallImage, IFormFile? UserManual);
