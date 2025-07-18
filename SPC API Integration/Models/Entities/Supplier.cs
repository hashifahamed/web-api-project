namespace SPC_API_Integration.Models.Entities
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public required string CompanyName { get; set; }
        public required string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime RegisteredDate { get; set; }

    }
}
