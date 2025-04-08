using GameStoreManager.Client.Models;

namespace GameStoreManager.Client.Services
{
    public interface IGameOffersApiService
    {
        public Task<GameSaleOffer> GetGameOfferByID(int id);
        public Task<GameSaleOffer> GetGameOfferByName(string name);
        public Task<GameSaleOffer> AddGameOffer(GameSaleOffer game);
        public Task<List<GameSaleOffer>> GetAllGameOffers();
        public Task<GameSaleOffer> UpdateGameOffer(GameSaleOffer gameOffer);
    }
}
