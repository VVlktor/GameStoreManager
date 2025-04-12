using GameStoreManager.Api.Models;
using GameStoreManager.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreManager.Api.Data
{
    public class GameStoreDbContext : DbContext
    {
        public DbSet<GameSaleOffer> SaleOffers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {
            
        }
    }
}
