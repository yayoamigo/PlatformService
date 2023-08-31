using PlatformServiceCore.Domain.Entity;

namespace PlatformServiceCore.Domain.RepositoryContracts
{
    public interface IPlatformRepo
    {
        Task SaveChanges();
        Task<IEnumerable<Platform>> GetAllPlatforms();
        Task<Platform> GetPlatformById(int id);
        Task CreatePlatform(Platform platform);
    }
}
