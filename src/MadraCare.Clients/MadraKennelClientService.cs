using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using MadraCare.Models;
using Newtonsoft;

namespace MadraCare.Clients
{

    public interface IMadraKennelService
    {
        Task<IEnumerable<Kennel>> GetKennels();
    }
    
    public class MadraKennelServiceClient: IMadraKennelService
    {
        private readonly HttpClient _httpClient;
        public MadraKennelServiceClient(HttpClient httpClient)
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