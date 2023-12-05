using System.Security.Cryptography;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using TreasureCache.Application.Files.Dtos;
using TreasureCache.Application.Images.Services.Interfaces;

namespace TreasureCache.Application.Images.Services;

public class ImageProcessor : IImageProcessor
{
    public async Task<FileDto> Resize(FileDto image, int width, int height)
    {
        using MemoryStream stream = new MemoryStream(image.ByteContent);
        using var loadedImage = await Image.LoadAsync(stream);
        
        loadedImage.Mutate(x => x.Resize(width, height));

        using MemoryStream outputStream = new MemoryStream();
        
        _ = loadedImage.Metadata.DecodedImageFormat ?? throw new NullReferenceException("Image format is null");
        
        await loadedImage.SaveAsync(outputStream, loadedImage.Metadata.DecodedImageFormat);

        image.ByteContent = outputStream.ToArray();

        return image;
    }
   
}
