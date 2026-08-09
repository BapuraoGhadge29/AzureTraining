namespace CustomerKYCManagement.DTOs
{
    public class TransferRequest
    {
        public string FromAccount { get; set; } = null!;
        public string ToAccount { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
