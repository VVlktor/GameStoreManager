using GameStoreManager.Api.Models;

namespace GameStoreManager.Api.Repositories
{
    public interface ISalesService
    {
        public Task<IEnumerable<Sale>> GetSalesFromPeriod(DateTime startDate, DateTime endDate);
        public Task<Sale> GetSaleById(int id);
        public Task<Sale> AddSale(Sale sale);
        public Task<bool> InsertSampleData();
    }
}
