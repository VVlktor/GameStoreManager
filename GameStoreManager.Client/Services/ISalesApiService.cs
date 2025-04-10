using GameStoreManager.Client.Models;

namespace GameStoreManager.Client.Services
{
    public interface ISalesApiService
    {
        public Task<List<Sale>> GetSalesFromPeriod(DateTime start, DateTime end);
    }
}
