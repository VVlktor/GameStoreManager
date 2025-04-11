using GameStoreManager.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : Controller
    {
        public static List<Sale> SalesList = new List<Sale>() { new() { Id=0, OfferId=1, DateOfPurchase=DateTime.Today.AddDays(-1) }, new() { DateOfPurchase=DateTime.Now.AddDays(10), Id=1, OfferId=3 } };
        //zmienic statyczną liste na ef
        [HttpGet("{startDate}/{endDate}")]
        public ActionResult<List<Sale>> GetSalesFromPeriod(DateTime startDate, DateTime endDate)
        {
            IEnumerable<Sale> sales = SalesList.Where(x=>x.DateOfPurchase >= startDate && x.DateOfPurchase <= endDate);
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public ActionResult<Sale> GetSaleById(int id)
        {
            Sale sale = SalesList.FirstOrDefault(x => x.Id == id);
            if(sale is null)
                return NotFound();

            return Ok(sale);
        }

        [HttpPost]
        public ActionResult<Sale> AddSale(Sale sale)
        {
            if (sale is null)
                return BadRequest();

            sale.DateOfPurchase = DateTime.Now;

            SalesList.Add(sale);
            return Ok(sale);
        }


    }
}
