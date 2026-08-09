using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.Entities
{
    public class Account
    {
        public Guid AccountId { get; set; }

        public Guid CustomerId { get; set; }

        public string AccountNumber { get; set; } = null!;

        public string AccountType { get; set; } = null!;

        public string BranchCode { get; set; } = null!;

        public string Currency { get; set; } = null!;

        public decimal Balance { get; set; }

        public AccountStatus Status { get; set; } 

        public DateTime OpeningDate { get; set; }

        public string RelationshipManager { get; set; } = null!;

        public Customer Customer { get; set; } = null!;
    }
}