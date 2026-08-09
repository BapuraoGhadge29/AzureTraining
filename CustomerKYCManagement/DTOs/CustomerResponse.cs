namespace CustomerKYCManagement.DTOs
{
    public class CustomerResponse
    {
        public string CustomerId { get; set; } =string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string PanNumber { get; set; } = string.Empty;

        public string KycStatus { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}