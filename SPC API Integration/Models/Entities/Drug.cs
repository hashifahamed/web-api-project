using System.ComponentModel.DataAnnotations;

namespace SPC_API_Integration.Models.Entities
{
    public class Drug
    {
        [Key]
        public int DrugID { get; set; }
        public String Name { get; set; }
        public String Manufacturer { get; set; }
        public int StockQuantity { get; set; }

    }
}
