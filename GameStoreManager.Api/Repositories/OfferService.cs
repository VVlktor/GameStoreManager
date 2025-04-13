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
            gameSaleOffer.LastAlterDate = DateTime.Now;
            var updatedGame = _dbContext.SaleOffers.Update(gameSaleOffer);
            await _dbContext.SaveChangesAsync();
            return updatedGame.Entity;
        }

        public async Task<bool> InsertSampleData()
        {
            List<GameSaleOffer> list = new()
            {
                new() { Name="Cyberpunk 2077", Description="Gra w swiecie przyszlosci", Platform="PC", Price=200, LastAlterDate=DateTime.Now.AddDays(-4).AddHours(-5)},
                new() { Name="The Witcher 3", Description="Na podstawie ksiazek Sapkowskiego", Platform="Playstation 4", Price=90, LastAlterDate=DateTime.Now.AddDays(-3).AddHours(-6)},
                new() { Name="Horizon Zero Dawn", Description="Pierwsza czesc przygod Aloy", Platform="Playstation 4", Price=50, LastAlterDate=DateTime.Now.AddDays(-1).AddHours(-2)},
                new() { Name="The Last Of Us Part I", Description="Apokaliptyczny swiat z zombie", Platform="Playstation 5", Price=70, LastAlterDate=DateTime.Now.AddDays(-6).AddHours(-7)},
                new() { Name="Subnautica", Description="Podwodny horror", Platform="Xbox one", Price=130, LastAlterDate=DateTime.Now.AddDays(-4).AddHours(-8)},
                new() { Name="Metro Exodus", Description="Kontynuacja przygod Artema z Metro 2033", Platform="Playstation 5", Price=259, LastAlterDate=DateTime.Now.AddDays(-7).AddHours(-6)},
                new() { Name="Detroit Become Human", Description="Interaktywna opowiesc", Platform="Playstation 4", Price=99, LastAlterDate=DateTime.Now.AddDays(-5).AddHours(-1)},
                new() { Name="Sons Of The Forest", Description="Survival na wyspie z kanibalami", Platform="PC", Price=139, LastAlterDate=DateTime.Now.AddDays(-3)},
                new() { Name="Portal II", Description="Kontynuacja slynnej gry Portal", Platform="PC", Price=19, LastAlterDate=DateTime.Now.AddDays(-9).AddHours(-5)},
                new() { Name="Doom Eternal", Description="Gra o zabijaniu demonow", Platform="Xbox Series X", Price=120, LastAlterDate=DateTime.Now.AddDays(-6).AddHours(-3)},
                new() { Name="Payday 2", Description="Dzien placy 2", Platform="PC", Price=20, LastAlterDate=DateTime.Now.AddDays(-9).AddHours(-8)},
                new() { Name="Need For Speed Unbound", Description="Gra wyscigowa", Platform="Xbox Series X", Price=299, LastAlterDate=DateTime.Now.AddDays(-1).AddHours(-3)}
            };

            await _dbContext.AddRangeAsync(list);
            int addedRows = await _dbContext.SaveChangesAsync();
            return addedRows == list.Count;
        }
    }
}
