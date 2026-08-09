using System.ComponentModel.DataAnnotations;
using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.Entities
{
    public class KycVerification
    {
        [Key]
        public Guid VerificationId { get; set; }

        public Guid CustomerId { get; set; }

        public VerificationStatus VerificationStatus { get; set; } 

        public string VerifiedBy { get; set; } =  null!;

        public DateTime? VerifiedDate { get; set; }

        public string Remarks { get; set; } = null!;

        public Customer? Customer { get; set; }
    }
}