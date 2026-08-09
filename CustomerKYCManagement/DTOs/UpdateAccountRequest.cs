using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.DTOs
{
    public class UpdateAccountRequest
    { 
        public string BranchCode { get; set; } = null!;

        public AccountStatus Status { get; set; } 

        public decimal Balance { get; set; }

        public string RelationshipManager { get; set; } = null!;
    }
}