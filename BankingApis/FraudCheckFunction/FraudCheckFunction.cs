using Azure.Messaging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FraudCheckFunction;

public class FraudCheckFunction
{
    private readonly ILogger<FraudCheckFunction> _logger;

    public FraudCheckFunction(ILogger<FraudCheckFunction> logger)
    {
        _logger = logger;
    }

    [Function("bgzen-FaudDetectionFunction")]
    public void Run([EventGridTrigger] CloudEvent cloudEvent)
    {
        _logger.LogInformation($"Fraud Validation for Event: {cloudEvent.Id}");
    }
}