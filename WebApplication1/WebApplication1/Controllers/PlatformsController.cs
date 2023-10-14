using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformServiceCore.ServicesContracts;
using AutoMapper;
using PlatformServiceCore.DTO;
using PlatformServiceCore.Domain.Entity;
using PlatformServiceCore.SyncDataServices.Http;

namespace PlatformServiceUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        private readonly IMapper _mapper;

        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformService platformService, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _platformService = platformService;

            _mapper = mapper;

            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlatforms()
        {
            var platforms = await _platformService.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlatformResponse>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]

        public async Task<IActionResult> GetPlatformById(int id)
        {
            var platform = await _platformService.GetPlatformById(id);
            if (platform == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PlatformResponse>(platform));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform(PlatformCreate platformRequest)
        {
            var platform = _mapper.Map<Platform>(platformRequest);
            var result = await _platformService.CreatePlatform(platform);
            if (result)
            {
                try
                {
                    var platformDto = _mapper.Map<PlatformResponse>(platform);
                    await _commandDataClient.SendPlatformToCommand(platformDto);

                }catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    
                }
                return CreatedAtRoute(nameof(GetPlatformById), new { Id = platform.Id }, _mapper.Map<PlatformResponse>(platform));
            }
            return BadRequest();
        }

    }
}


