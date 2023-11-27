namespace TreasureCache.Presentation.Requests;


public record CreateProductRequest(string Name, string Description, decimal Price, int Discount, int Count, bool IsActive, 
    int CategoryId, IFormFile LargeImage, IFormFile SmallImage, IFormFile? UserManual);
