using Microsoft.AspNetCore.Mvc;
using SPC_API_Integration.Data;
using SPC_API_Integration.Models;
using SPC_API_Integration.Models.Entities;

namespace SPC_API_Integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public PharmacyController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost("register")]
        public IActionResult RegisterPharmacy(AddPharmacyDTO dto)
        {
            var pharmacy = new Pharmacy
            {
                PharmacyName = dto.PharmacyName,
                ContactPerson = dto.ContactPerson,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                RegisteredDate = DateTime.Now
            };

            dBContext.Pharmacies.Add(pharmacy);
            dBContext.SaveChanges();

            return Ok(pharmacy);
        }

        // Optional: list all registered pharmacies
        [HttpGet("all")]
        public IActionResult GetAllPharmacies()
        {
            return Ok(dBContext.Pharmacies.ToList());
        }
    }
}
