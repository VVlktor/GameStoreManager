using GameStoreManager.Api.Models;
using GameStoreManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<ActionResult<List<Sale>>> GetSalesFromPeriod(DateTime startDate, DateTime endDate)
        {
            IEnumerable<Sale> sales = await _salesService.GetSalesFromPeriod(startDate, endDate);
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSaleById(int id)
        {
            Sale sale = await _salesService.GetSaleById(id);
            if(sale is null)
                return NotFound();

            return Ok(sale);
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> AddSale(Sale sale)
        {
            if (sale is null)
                return BadRequest();

            sale.DateOfPurchase = DateTime.Now;

            await _salesService.AddSale(sale);
            return Ok(sale);
        }

        [HttpPost("insertData")]
        public async Task<ActionResult<bool>> InsertSampleData()
        {
            if(!(await _salesService.InsertSampleData()))
                return BadRequest(false);
            return Ok(true);
        }
    }
}
