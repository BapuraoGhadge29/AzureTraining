using System.Net;
using System.Text.Json;
using BankingPayment.FunctionApp.Models;
using BankingPayment.FunctionApp.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

public class PaymentTransferFunction
{
    private readonly ILogicAppService _logicAppService;
    public PaymentTransferFunction(ILogicAppService logicAppService)
    {
        _logicAppService = logicAppService;
    }

    [Function("PaymentTransfer")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function,"post")] HttpRequestData req)
    {
         
        var request = await JsonSerializer.DeserializeAsync<PaymentTransferRequest>(req.Body);

        if (request == null)
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            return badResponse;
        }
        await _logicAppService.SendToLogicAppAsync(request);

        var response = req.CreateResponse(HttpStatusCode.OK);

        await response.WriteAsJsonAsync(new PaymentTransferResponse
            {
                Success = true,
                Message =
                "Logic App Triggered Successfully"
            });

        return response;
    }
}