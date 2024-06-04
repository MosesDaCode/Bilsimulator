using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services.ApiService
{
    public class GetTheApi
    {
        private readonly HttpClient _httpClient;

        public GetTheApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RandomUsers> FetchApiData()
        {
            string apiUrl = "https://randomuser.me/api/";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                return data.Results[0].Name;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
        }
    }
}
