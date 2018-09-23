using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using MadraCare.Models;

namespace MadraCare.Clients
{

    public interface IMadraService: IMadraKennelService
    {

    }
    
    public class MadraGatewayClient: IMadraService
    {
        private readonly HttpClient _httpClient;
        public MadraGatewayClient(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }

        public async Task<IEnumerable<Kennel>> GetKennels()
        {
            var result = await _httpClient.GetAsync("/kennel");
            if(result.IsSuccessStatusCode)
                return await result.Content.ReadAsJsonAsync<IEnumerable<Kennel>>();

            return null;
        }
    }
}