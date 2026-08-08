namespace SharedContracts.Models;

public class TransactionEvent
{
    public string TransactionId { get; set; } = Guid.NewGuid().ToString();

    public string CustomerName { get; set; } = string.Empty;

    public string AccountNumber { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }

    public string TransactionType { get; set; } = string.Empty;
}