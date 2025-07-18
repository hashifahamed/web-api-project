using System.ComponentModel.DataAnnotations;

namespace SPC_API_Integration.Models.Entities
{

    public class DrugOrder
    {
       
        [Key]
        public int OrderID { get; set; }
        public String PharmacyName { get; set; }
        public int DrugID { get; set; }
        public int QuantityOrdered { get; set; }
        public DateTime OrderDate { get; set; }
        public String Status { get; set; }
        
    }
}
