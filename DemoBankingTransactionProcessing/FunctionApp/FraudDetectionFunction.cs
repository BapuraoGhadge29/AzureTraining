// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DemoBankingTransactionProcessing.FunctionApp.Function;

public class FraudDetectionFunction
{
    private readonly ILogger<FraudDetectionFunction> _logger;

    public FraudDetectionFunction(ILogger<FraudDetectionFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(FraudDetectionFunction))]
    public void Run([EventGridTrigger] EventGridEvent cloudEvent)
    {
        _logger.LogInformation("Event type: {type}, Event subject: {subject},Event Data;{data}"
        , cloudEvent.EventType, cloudEvent.Subject,cloudEvent.Data);
    }
}