namespace BankingPayment.FunctionApp.Models;
public class PaymentTransferRequest
{
    public string CustomerName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string FromAccount { get; set; } = string.Empty;

    public string ToAccount { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }
}