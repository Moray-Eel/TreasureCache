namespace TreasureCache.Core.Interfaces.Repositories;

public interface IFileStorageService
{
    public Task GetPathAndWrite(byte[] file);
}