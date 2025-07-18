using Microsoft.AspNetCore.Mvc;
using SPC_API_Integration.Data;
using SPC_API_Integration.Models;
using SPC_API_Integration.Models.Entities;
using System.Linq;

namespace SPC_API_Integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockServicesController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public StockServicesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost("Add")]
        public IActionResult AddStock(AddStockDTO addStockDTO)
        {
            var Stock = new DrugStock()
            {
                DrugName = addStockDTO.DrugName,
                QuantityAvailable = addStockDTO.Quantity,
                Source = addStockDTO.Source,
                LastUpdated = DateTime.Now

            };

            dBContext.DrugStocks.Add(Stock);
            dBContext.SaveChanges();

            return Ok(Stock);
        }

        [HttpPut("Update")]
        public IActionResult UpdateStock(UpdateStockDTO updateStockDTO)
        {
            var Stock = dBContext.DrugStocks.FirstOrDefault(s => s.DrugID == updateStockDTO.DrugId);
            if (Stock == null)
                return NotFound("Drug not found.");

            Stock.QuantityAvailable = updateStockDTO.NewQuantity;
            Stock.LastUpdated = DateTime.Now;

            dBContext.SaveChanges();

            return Ok(Stock);
        }

        [HttpGet("View Current Stock")]
        public IActionResult GetStockById(int id)
        {
            var stock = dBContext.DrugStocks.FirstOrDefault(s => s.DrugID == id);
            if (stock == null)
                return NotFound();

            return Ok(stock);
        }

    }
}
