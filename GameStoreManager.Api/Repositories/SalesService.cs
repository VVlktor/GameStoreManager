using GameStoreManager.Api.Data;
using GameStoreManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreManager.Api.Repositories
{
    public class SalesService : ISalesService
    {
        private readonly GameStoreDbContext _dbContext;

        public SalesService(GameStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<Sale> AddSale(Sale sale)
        {
            var addedSale = await _dbContext.Sales.AddAsync(sale);
            await _dbContext.SaveChangesAsync();
            return addedSale.Entity;
        }

        public async Task<Sale> GetSaleById(int id)
        {
            return await _dbContext.Sales.FindAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetSalesFromPeriod(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Sales.Where(x => x.DateOfPurchase >= startDate && x.DateOfPurchase <= endDate).ToListAsync();
        }
    }
}
