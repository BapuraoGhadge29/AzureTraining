using CustomerKYCManagement.Constants;
namespace CustomerKYCManagement.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

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

        public ICollection<Account> Accounts { get; set; } = null!;
    }
}
