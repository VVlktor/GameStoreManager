using GameStoreManager.Api.Repositories;
using GameStoreManager.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameOffersController : ControllerBase
    {
        private readonly IOffersService _offerService;

        public GameOffersController(IOffersService offerService)
        {
            _offerService = offerService;
        }

        public static List<GameSaleOffer> GamesOffers = new() { new() { Id = 0, Name = "Cyberpunk 2077", LastAlterDate = DateTime.Now, Description = "game made by cd project red", Platform = "Playstation 4", Price = 120 }, new() { Id = 1, Name = "The witcher 3", LastAlterDate = DateTime.Now.AddDays(1), Price = 50, Description = "Other game by cdpr", Platform = "Playstation 5" } };

        [HttpGet("{id}")]
        public async Task<ActionResult<GameSaleOffer>> GetGameOfferById(int id)
        {
            GameSaleOffer offer = await _offerService.GetGameOfferById(id);

            if (offer is null)
                return BadRequest();

            return Ok(offer);
        }

        [HttpGet]
        public async Task<ActionResult<List<GameSaleOffer>>> GetAllGameOffers()
        {
            List<GameSaleOffer> list = await _offerService.GetAllGameOffers();
            if (list is null)
                return BadRequest();
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<GameSaleOffer>> AddGameOffer(GameSaleOffer newGame)
        {
            if (newGame is null)
                return BadRequest();

            return Ok(await _offerService.AddGameOffer(newGame));
        }

        [HttpPut]
        public async Task<ActionResult<GameSaleOffer>> UpdateGameOffer(GameSaleOffer gameSaleOffer)
        {
            if (gameSaleOffer is null)
                return BadRequest();

            GameSaleOffer updatedSaleOffer = await _offerService.UpdateGameOffer(gameSaleOffer);

            if (updatedSaleOffer is null)
                return BadRequest();

            return Ok(updatedSaleOffer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGameOffer(int id)
        {
            return Ok(await _offerService.DeleteGameOffer(id));
        }

        [HttpPost("insertData")]
        public async Task<ActionResult<bool>> InsertSampleData()
        {
            if(!(await _offerService.InsertSampleData()))
                return BadRequest(false);
            return Ok(true);
        }
    }
}
