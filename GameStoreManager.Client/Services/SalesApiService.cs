using GameStoreManager.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace GameStoreManager.Client.Services
{
    public class SalesApiService : ISalesApiService
    {
        private readonly HttpClient _httpClient;

        public SalesApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<List<Sale>> GetSalesFromPeriod(DateTime start, DateTime end)
        {
            var response = await _httpClient.GetAsync($"Sales/{start.Date.ToString("yyyy-MM-dd")}T00:00:00Z/{end.Date.ToString("yyyy-MM-dd")}T23:59:59Z");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Request failed: {response.StatusCode}");

            var sales = await response.Content.ReadFromJsonAsync<List<Sale>>();
            return sales!;
        }
    }

}
