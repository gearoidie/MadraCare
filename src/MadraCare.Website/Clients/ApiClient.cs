using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MadraCare.Website.Clients
{

    public interface IMadraApiClient
    {
        Task<String> GetValues();
    }
    
    public class MadraApiClient:IMadraApiClient
    {
        private readonly HttpClient _httpClient;
        public MadraApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }

        public async Task<string> GetValues()
        {
            var result = await _httpClient.GetAsync("/api/values");
            if(result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }
    }
}