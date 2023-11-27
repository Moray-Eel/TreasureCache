namespace TreasureCache.Core.Interfaces.Repositories;

public interface IFileHandlerService
{
    public Task Handle(byte[] file);
}