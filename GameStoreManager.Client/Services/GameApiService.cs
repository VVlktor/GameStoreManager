using GameStoreManager.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace GameStoreManager.Client.Services
{
    public class GameApiService : IGameApiService
    {
        public Task<List<Game>> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetGameByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetGameByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Game> AddGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
