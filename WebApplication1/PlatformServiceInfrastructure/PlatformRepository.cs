using PlatformServiceCore.Domain.Entity;
using PlatformServiceCore.Domain.RepositoryContracts;
using PlatformServiceInfrastructure.DBContext;

namespace PlatformServiceInfrastructure
{
    public class PlatformRepository : IPlatformRepo
    {
        private readonly PlatformDbContext _DBContext;

        public PlatformRepository(PlatformDbContext dbContext)
        {
            _DBContext = dbContext;
        }
        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _DBContext.Platforms.Add(platform);       
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
           return _DBContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _DBContext.Platforms.First(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_DBContext.SaveChanges() >= 0);
        }
    }
}