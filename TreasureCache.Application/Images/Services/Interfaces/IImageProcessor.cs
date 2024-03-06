using TreasureCache.Application.UserFiles.Dtos;

namespace TreasureCache.Application.Images.Services.Interfaces;

public interface IImageProcessor
{
    public Task<FileDto> Resize(FileDto file, int width, int height);
}