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

        public async Task<bool> InsertSampleData()
        {
            List<Sale> sales = new()
            {
                new(){ DateOfPurchase = DateTime.Now.AddDays(-10), OfferId=143 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-9), OfferId=134 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-9), OfferId=165 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-9), OfferId=123 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-7), OfferId=176 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-6), OfferId=156 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-6), OfferId=145 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-6), OfferId=186 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-5), OfferId=198 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-5), OfferId=197 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-5), OfferId=167 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-5), OfferId=100 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-3), OfferId=101 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-2), OfferId=104 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-2), OfferId=105 },
                new(){ DateOfPurchase = DateTime.Now.AddDays(-1), OfferId=114 },
                new(){ DateOfPurchase = DateTime.Now, OfferId=106 },

            };
            await _dbContext.AddRangeAsync(sales);
            int numRows = await _dbContext.SaveChangesAsync();
            return numRows == sales.Count;
        }
    }
}
