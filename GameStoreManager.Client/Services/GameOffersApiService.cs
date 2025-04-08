using GameStoreManager.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace GameStoreManager.Client.Services
{
    public class GameOffersApiService : IGameOffersApiService
    {
        private readonly HttpClient _httpClient;

        public GameOffersApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GameSaleOffer> GetGameOfferByID(int id)
        {
            var response = await _httpClient.GetAsync($"gameoffersD/{id}");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Request failed: {response.StatusCode}");

            var game = await response.Content.ReadFromJsonAsync<GameSaleOffer>();
            return game!;
        }

        public async Task<GameSaleOffer> GetGameOfferByName(string name)
        {
            var response = await _httpClient.GetAsync($"gameoffers/{name}");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Request failed: {response.StatusCode}");

            var game = await response.Content.ReadFromJsonAsync<GameSaleOffer>();
            return game!;
        }

        public async Task<GameSaleOffer> AddGameOffer(GameSaleOffer newGame)
        {
            var content = new StringContent(JsonSerializer.Serialize(newGame), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("gameoffers", content);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Request failed: {response.StatusCode}");

            var createdGame = await response.Content.ReadFromJsonAsync<GameSaleOffer>();
            return createdGame!;
        }

        public async Task<List<GameSaleOffer>> GetAllGameOffers()
        {
            var response = await _httpClient.GetAsync("gameoffers");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Request failed: {response.StatusCode}");

            var game = await response.Content.ReadFromJsonAsync<List<GameSaleOffer>>();
            return game!;
        }

        public async Task<GameSaleOffer> UpdateGameOffer(GameSaleOffer gameOffer)
        {
            var content = new StringContent(JsonSerializer.Serialize(gameOffer), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("gameoffers", content);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Request failed: {response.StatusCode}");

            var updatedGameOffer = await response.Content.ReadFromJsonAsync<GameSaleOffer>();
            return updatedGameOffer!;
        }
    }
}
