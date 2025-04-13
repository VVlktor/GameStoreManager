using GameStoreManager.Client.Models;

namespace GameStoreManager.Api.Repositories
{
    public interface IOffersService
    {
        public Task<GameSaleOffer> GetGameOfferById(int id);
        public Task<List<GameSaleOffer>> GetAllGameOffers();
        public Task<GameSaleOffer> AddGameOffer(GameSaleOffer newGame);
        public Task<GameSaleOffer> UpdateGameOffer(GameSaleOffer gameSaleOffer);
        public Task<bool> DeleteGameOffer(int id);
        public Task<bool> InsertSampleData();
    }
}
