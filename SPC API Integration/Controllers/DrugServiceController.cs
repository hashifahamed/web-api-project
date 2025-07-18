using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPC_API_Integration.Data;
using SPC_API_Integration.Models;
using SPC_API_Integration.Models.Entities;
using System.Linq;

namespace SPC_API_Integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugServiceController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public DrugServiceController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet("search")]
        public IActionResult SearchDrugs(string name)
        {
            var result = dBContext.DrugStocks
                .Where(d => d.DrugName.Contains(name))
                .ToList();

            if (!result.Any())
                return NotFound("No drugs found matching the name.");

            return Ok(result);
        }

        [HttpPost("place-order")]
        public IActionResult PlaceOrder(PlaceOrderDTO dto)
        {
            var pharmacyExists = dBContext.Pharmacies.Any(p => p.PharmacyName == dto.PharmacyName);
            if (!pharmacyExists)
                return BadRequest("Pharmacy is not registered with SPC.");

            var drug = dBContext.DrugStocks.FirstOrDefault(d => d.DrugID == dto.DrugID);
            if (drug == null)
                return NotFound("Drug not found.");

            if (drug.QuantityAvailable < dto.QuantityOrdered)
                return BadRequest("Insufficient stock available.");

            // Deduct stock
            drug.QuantityAvailable -= dto.QuantityOrdered;

            // Create order
            var order = new DrugOrder
            {
                PharmacyName = dto.PharmacyName,
                DrugID = dto.DrugID,
                QuantityOrdered = dto.QuantityOrdered,
                OrderDate = DateTime.Now,
                Status = "Pending"
            };

            dBContext.DrugOrders.Add(order);
            dBContext.SaveChanges();

            return Ok(order);
        }

        [HttpGet("track-order/{orderId}")]
        public IActionResult TrackOrder(int orderId)
        {
            var order = dBContext.DrugOrders
                .FirstOrDefault(o => o.OrderID == orderId);

            if (order == null)
                return NotFound("Order not found.");

            return Ok(order);

        }
    }
}
