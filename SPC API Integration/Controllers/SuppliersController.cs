using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC_API_Integration.Data;
using SPC_API_Integration.Models;
using SPC_API_Integration.Models.Entities;

namespace SPC_API_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public SuppliersController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            var allSuppliers = dBContext.Suppliers.ToList();
            return Ok(allSuppliers);
        }

        [HttpPut("Update")]
        public IActionResult UpdateSupplier(UpdateSupplierDTO updateSupplierDTO)
            { 
            var Supplier = dBContext.Suppliers.FirstOrDefault(s => s.SupplierID == updateSupplierDTO.SupplierID);

            if(Supplier==null)
            {
                return NotFound($"Supplier with ID {updateSupplierDTO.SupplierID} not found.");

            }
            Supplier.CompanyName = updateSupplierDTO.CompanyName;
            Supplier.ContactPerson = updateSupplierDTO.ContactPerson;
            Supplier.Email = updateSupplierDTO.Email;
            Supplier.PhoneNumber = updateSupplierDTO.PhoneNumber;
            Supplier.Address = updateSupplierDTO.Address;

            dBContext.SaveChanges();

            return Ok(Supplier);

        }

        [HttpPost("Add")]
        public IActionResult AddSupplier(AddSupplierDTO addSupplierDTO)
        {
            var SupplierEntity = new Supplier()
            {
                CompanyName = addSupplierDTO.CompanyName,
                ContactPerson = addSupplierDTO.ContactPerson,
                Email = addSupplierDTO.Email,
                PhoneNumber = addSupplierDTO.PhoneNumber,
                Address = addSupplierDTO.Address,
                RegisteredDate = addSupplierDTO.RegisteredDate,

            };

            dBContext.Suppliers.Add(SupplierEntity);
            dBContext.SaveChanges();

            return Ok(SupplierEntity);
        }

   }
}