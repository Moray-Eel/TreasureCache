using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureCache.Infrastructure.Queries.Category.Dtos;
using TreasureCache.Infrastructure.Queries.Product.Dtos;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.ViewModels.Administration;

public class ProductModalViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; } 
    public decimal BasePrice { get; set; } 
    public int Discount { get; set; } 
    public int Count { get; set; } 
    public bool IsActive { get; set; } 
}