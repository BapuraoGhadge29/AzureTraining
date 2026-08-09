using System.ComponentModel.DataAnnotations;
using CustomerKYCManagement.Constants;

namespace CustomerKYCManagement.Entities
{
    public class KycDocument
    {
        [Key]
        public Guid DocumentId { get; set; }

        public Guid CustomerId { get; set; }

        public string DocumentType { get; set; } = null!;

        public string BlobUrl { get; set; } = null!;

        public int Version { get; set; }

        public VerificationStatus VerificationStatus { get; set; }

        public DateTime UploadedDate { get; set; }
    }
}