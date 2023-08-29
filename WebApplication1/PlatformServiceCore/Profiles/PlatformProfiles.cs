using AutoMapper;
using PlatformServiceCore.Domain.Entity;
using PlatformServiceCore.DTO;

namespace PlatformServiceCore.Profiles
{
    public class PlatformProfiles: Profile
    {
        public PlatformProfiles()
        {
            CreateMap<Platform, PlatformResponse>();
            CreateMap<PlatformCreate, Platform>();
        }
    }
}
