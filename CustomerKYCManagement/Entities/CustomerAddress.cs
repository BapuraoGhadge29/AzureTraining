using System.ComponentModel.DataAnnotations;
using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.Entities
{
    public class CustomerAddress
    {
        [Key]
        public Guid CustomerAddessId { get; set; }
        public Guid AddressId { get; set; }

        public Guid CustomerId { get; set; }

        public AddressType AddressType { get; set; } 

        public string AddressLine1 { get; set; } = null!;

        public string AddressLine2 { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string Country { get; set; } = null!;

        public Customer? Customer { get; set; }
    }
}