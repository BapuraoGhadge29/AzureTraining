using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.DTOs
{
    public class AccountResponse
    { 
         public string AccountId { get; set; }= null!;
        public string CustomerId { get; set; }= null!;

        public string AccountNumber { get; set; } = null!;

        public string AccountType { get; set; } = null!;

        public string BranchCode { get; set; } = null!;

        public string Currency { get; set; } = null!;

        public AccountStatus Status { get; set; } 

        public DateTime OpeningDate { get; set; }

        public string RelationshipManager { get; set; } = null!;
    }
}