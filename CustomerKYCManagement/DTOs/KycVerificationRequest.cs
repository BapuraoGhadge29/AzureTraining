using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.DTOs
{
    public class KycVerificationRequest
    {
        public Guid CustomerId { get; set; }

        public VerificationStatus VerificationStatus { get; set; } 

        public string VerifiedBy { get; set; } =  null!;

        public DateTime? VerifiedDate { get; set; }

        public string Remarks { get; set; } = null!;
    }
}