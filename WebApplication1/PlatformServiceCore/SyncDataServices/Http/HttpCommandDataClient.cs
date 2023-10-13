using PlatformServiceCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformServiceCore.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;

        public HttpCommandDataClient(HttpClient httpClient)
        {
              _httpClient = httpClient;
        }


        public async Task SendPlatformToCommand(PlatformResponse plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
                );
            var response = await _httpClient.PostAsync("http://localhost:8161/api/c/Platforms", httpContent);
        }
    }
}
