using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.DTOs
{
    public class CustomerAddressRequest
    {
        public Guid CustomerId { get; set; }

        public AddressType AddressType { get; set; } 

        public string AddressLine1 { get; set; } = null!;

        public string AddressLine2 { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string Country { get; set; } = null!;
    }
}