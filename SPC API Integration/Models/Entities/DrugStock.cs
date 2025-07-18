using System.ComponentModel.DataAnnotations;

namespace SPC_API_Integration.Models.Entities
{
    public class DrugStock
    {
        [Key]
        public int DrugID { get; set; }
        public String DrugName { get; set; }
        public int QuantityAvailable { get; set; }
        public String Source { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
