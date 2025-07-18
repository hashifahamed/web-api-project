using Microsoft.EntityFrameworkCore;
using SPC_API_Integration.Models.Entities;

namespace SPC_API_Integration.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        { 

        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<DrugStock> DrugStocks { get; set; }
        public DbSet<Drug> drugs { get; set; }
        public DbSet<DrugOrder> DrugOrders { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
    }
}
