using Riok.Mapperly.Abstractions;
using TreasureCache.Application.Files;
using TreasureCache.Application.Files.Dtos;
using TreasureCache.Application.Products.Commands.CreateProductCommand;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.Mappers;

public static class RequestToCommandMapper
{
    public static async Task<CreateProductCommand> AsCommand(this CreateProductRequest request)
    {
        var largeImage = await request.LargeImage.ToFileDto();
        var smallImage = await request.SmallImage.ToFileDto();
        var userManual = request.UserManual is not null 
            ? await request.UserManual.ToFileDto() 
            : null;
        
        return new CreateProductCommand(request.Name, request.Description, request.Price, request.Discount, 
                request.Count, request.IsActive, request.CategoryId, largeImage, 
                smallImage, userManual);
    }

    private static async Task<FileDto> ToFileDto(this IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        
        await file
            .CopyToAsync(memoryStream);

        var extension = Path.GetExtension(file.FileName);
        var bytes = memoryStream.ToArray();
        
        return new FileDto()
        {
            Name = file.Name,
            FileType = file.ContentType.Contains("image") ? FileType.Image : FileType.Document,
            Extension = extension,
            ByteContent = bytes
        };
    }
}