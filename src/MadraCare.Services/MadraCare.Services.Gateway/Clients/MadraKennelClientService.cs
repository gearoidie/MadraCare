using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MadraCare.Services.Gateway.Clients
{

    public interface IMadraKennelService
    {
        Task<String> GetKennels();
    }
    
    public class MadraKennelServiceClient: IMadraKennelService
    {
        private readonly HttpClient _httpClient;
        public MadraKennelServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }

        public async Task<string> GetKennels()
        {
            var result = await _httpClient.GetAsync("/kennel");
            if(result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }
    }
}