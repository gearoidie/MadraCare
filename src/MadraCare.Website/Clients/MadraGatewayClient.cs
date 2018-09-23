using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MadraCare.Website.Clients
{

    public interface IMadraService
    {
        Task<String> GetKennels();
    }
    
    public class MadraGatewayClient: IMadraService
    {
        private readonly HttpClient _httpClient;
        public MadraGatewayClient(HttpClient httpClient)
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