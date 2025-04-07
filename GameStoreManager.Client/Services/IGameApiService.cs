using GameStoreManager.Client.Models;

namespace GameStoreManager.Client.Services
{
    public interface IGameApiService
    {
        public Task<Game> GetGameByID(int id);
        public Task<Game> GetGameByName(string name);
        public Task<Game> AddGame(Game game);
        public Task<List<Game>> GetAllGames();
    }
}
