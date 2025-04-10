using GameStoreManager.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameOffersController : ControllerBase
    {
        public static List<GameSaleOffer> GamesOffers = new() { new() { Id=0, Name="Cyberpunk 2077", LastAlterDate= DateTime.Now,  Description="game made by cd project red", Platform="Playstation 4", Price=120 }, new() { Id=1, Name="The witcher 3", LastAlterDate = DateTime.Now.AddDays(1), Price =50, Description="Other game by cdpr", Platform="Playstation 5" } };

        [HttpGet("{id}")]
        public ActionResult<GameSaleOffer> GetGameOfferById(int id)
        {
            if (GamesOffers.Any(x => x.Id == id))
                return Ok(GamesOffers.FirstOrDefault(x => x.Id == id));
            return BadRequest();
        }

        [HttpGet]
        public ActionResult<GameSaleOffer> GetAllGameOffers()
        {
            return Ok(GamesOffers);
        }

        [HttpPost]
        public ActionResult<GameSaleOffer> AddGameOffer(GameSaleOffer newGame)
        {
            if (newGame is null)
                return BadRequest();

            newGame.LastAlterDate = DateTime.Now;
            newGame.Id = GamesOffers.Count;//do usuniecia jak wprowadze ef
            GamesOffers.Add(newGame);

            return Ok(newGame);
        }

        [HttpPut]
        public ActionResult<GameSaleOffer> UpdateGameOffer(GameSaleOffer gameSaleOffer)
        {
            if(gameSaleOffer is null)
                return BadRequest();

            var giera = GamesOffers.FirstOrDefault(x => x.Id == gameSaleOffer.Id);

            if (giera is null)
                return NotFound();

            giera.Description = gameSaleOffer.Description;
            giera.LastAlterDate = DateTime.Now;
            giera.Name = gameSaleOffer.Name;
            giera.Platform = gameSaleOffer.Platform;
            giera.Price = gameSaleOffer.Price;
            return Ok(giera);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteGameOffer(int id)
        {
            var gra = GamesOffers.FirstOrDefault(x => x.Id == id);

            if(gra is null)
                return NotFound(false);

            GamesOffers.Remove(gra);

            return Ok(true);
        }
    }
}
