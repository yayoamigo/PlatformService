using PlatformServiceCore.Domain.Entity;
using PlatformServiceCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformServiceCore.ServicesContracts
{
    public interface IPlatformService
    {
        Task<IEnumerable<Platform>> GetAll();
        Task<Platform> GetPlatformById(int id);
        Task<bool> CreatePlatform(Platform platform);
    }
}
