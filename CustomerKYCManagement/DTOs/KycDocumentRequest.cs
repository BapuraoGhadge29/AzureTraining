using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.DTOs
{
    public class KycDocumentRequest
    {
        public Guid CustomerId { get; set; }

        public string DocumentType { get; set; } = null!;

        public string BlobUrl { get; set; } = null!;

        public int Version { get; set; }

        public VerificationStatus VerificationStatus { get; set; }

        public DateTime UploadedDate { get; set; }
    }
}