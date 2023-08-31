using PlatformServiceCore.Domain.Entity;
using PlatformServiceCore.Domain.RepositoryContracts;
using PlatformServiceCore.ServicesContracts;
using Microsoft.Extensions.Logging;

namespace PlatformServiceCore.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly ILogger<PlatformService> _logger;

        public PlatformService(IPlatformRepo platformRepo, ILogger<PlatformService> logger)
        {
            _platformRepo = platformRepo;
            _logger = logger;
        }



        public async Task<bool> CreatePlatform(Platform platform)
        {
            try
            {
                _platformRepo.CreatePlatform(platform);
                await _platformRepo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return false;


            }
        }

        public async Task<IEnumerable<Platform>> GetAll()
        {
            return await _platformRepo.GetAllPlatforms();
        }

        public async Task<Platform> GetPlatformById(int id)
        {
            return await _platformRepo.GetPlatformById(id);
        }
    }
}
