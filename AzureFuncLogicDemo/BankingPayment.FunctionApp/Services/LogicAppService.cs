using System.Text;
using System.Text.Json;
using BankingPayment.FunctionApp.Models;
using Microsoft.Extensions.Configuration;
namespace BankingPayment.FunctionApp.Services;
public class LogicAppService : ILogicAppService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public LogicAppService(HttpClient httpClient,IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    public async Task SendToLogicAppAsync(PaymentTransferRequest request)
    {
        var logicAppUrl = Environment.GetEnvironmentVariable("LogicAppUrl");
        var json =JsonSerializer.Serialize(request);
        var content = new StringContent(json,Encoding.UTF8,"application/json");
        var response = await _httpClient.PostAsync(logicAppUrl,content);
        response.EnsureSuccessStatusCode();
    }
}