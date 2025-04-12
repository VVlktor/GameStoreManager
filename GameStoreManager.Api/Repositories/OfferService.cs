using GameStoreManager.Api.Data;
using GameStoreManager.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreManager.Api.Repositories
{
    public class OfferService : IOffersService
    {
        private readonly GameStoreDbContext _dbContext;

        public OfferService(GameStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GameSaleOffer> AddGameOffer(GameSaleOffer newGame)
        {
            newGame.LastAlterDate = DateTime.Now;
            var addedGame = await _dbContext.SaleOffers.AddAsync(newGame);
            await _dbContext.SaveChangesAsync();
            return addedGame.Entity;
        }

        public async Task<bool> DeleteGameOffer(int id)
        {
            GameSaleOffer offer = await _dbContext.SaleOffers.FirstOrDefaultAsync(x => x.Id == id);

            if (offer is null)
                return false;

            _dbContext.SaleOffers.Remove(offer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<GameSaleOffer>> GetAllGameOffers()
        {
            return await _dbContext.SaleOffers.ToListAsync();
        }

        public async Task<GameSaleOffer> GetGameOfferById(int id)
        {
            return await _dbContext.SaleOffers.FindAsync(id);
        }

        public async Task<GameSaleOffer> UpdateGameOffer(GameSaleOffer gameSaleOffer)
        {
            var updatedGame = _dbContext.SaleOffers.Update(gameSaleOffer);
            await _dbContext.SaveChangesAsync();
            return updatedGame.Entity;
        }
    }
}
