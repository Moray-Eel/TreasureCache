using Riok.Mapperly.Abstractions;
using TreasureCache.Application.Product.Commands.CreateProductCommand;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.Mappers;

[Mapper]
public static partial class RequestToCommandMapper
{
    //public static partial CreateProductCommand AsCommand(this CreateProductRequest request);

    private static async Task<byte[]> IFormFileToBytes(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        
        await file
            .CopyToAsync(memoryStream);
            
        return memoryStream
            .ToArray();
    }
}