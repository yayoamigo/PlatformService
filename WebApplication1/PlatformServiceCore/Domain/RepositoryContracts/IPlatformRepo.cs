using PlatformServiceCore.Domain.Entity;

namespace PlatformServiceCore.Domain.RepositoryContracts
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}
