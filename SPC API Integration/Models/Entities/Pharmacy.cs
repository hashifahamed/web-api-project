namespace SPC_API_Integration.Models.Entities
{
   
        public class Pharmacy
        {
            public int PharmacyId { get; set; }
            public string PharmacyName { get; set; }
            public string ContactPerson { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public DateTime RegisteredDate { get; set; }
        }

    }

