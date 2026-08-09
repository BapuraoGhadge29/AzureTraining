using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.DTOs
{
    public class AccountRequest
    { 
        public string CustomerId { get; set; }=null!;

        public string AccountNumber { get; set; } = null!;

        public string AccountType { get; set; } = null!;
        public decimal Balance { get; set; }

        public string BranchCode { get; set; } = null!;

        public string Currency { get; set; } = null!;

        public AccountStatus Status { get; set; } 

        public DateTime OpeningDate { get; set; }

        public string RelationshipManager { get; set; } = null!;
    }
}