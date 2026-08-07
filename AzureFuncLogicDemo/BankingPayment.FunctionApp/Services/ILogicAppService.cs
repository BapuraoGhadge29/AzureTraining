using BankingPayment.FunctionApp.Models;
namespace BankingPayment.FunctionApp.Services;
public interface ILogicAppService
{
    Task SendToLogicAppAsync(PaymentTransferRequest request);
}
