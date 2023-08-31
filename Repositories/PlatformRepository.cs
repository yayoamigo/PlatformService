using Microsoft.EntityFrameworkCore;
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
        async public Task CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            try 
            {
                await _DBContext.Platforms.AddAsync(platform);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

        async public Task<IEnumerable<Platform>> GetAllPlatforms()
        {
            return await _DBContext.Platforms.ToListAsync();
        }

        async public Task<Platform> GetPlatformById(int id)
        {
            return await _DBContext.Platforms.FirstOrDefaultAsync(p => p.Id == id);
        }

        async public Task SaveChanges()
        {
            await _DBContext.SaveChangesAsync();
        }

        
    }
}