using CustomerKYCManagement.Constants;
namespace CustomerKYCManagement.DTOs
{
    public class CustomerRequest
    {

        public string CustomerId { get; set; } = null!;
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string MobileNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string PANNumber { get; set; } = null!;

        public string AadhaarNumber { get; set; } = null!;

        public string Occupation { get; set; } = null!;

        public CustomerCategory CustomerCategory { get; set; } 

        public CustomerStatus CustomerStatus { get; set; }
    }
}
