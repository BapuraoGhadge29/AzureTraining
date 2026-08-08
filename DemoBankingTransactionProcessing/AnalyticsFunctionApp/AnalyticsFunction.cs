using System;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace AnalyticsFunctionApp.Function;

public class AnalyticsFunction
{
    private readonly ILogger<AnalyticsFunction> _logger;
    private readonly IConfiguration _configuration;
    public AnalyticsFunction(ILogger<AnalyticsFunction> logger,IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [Function(nameof(AnalyticsFunction))]
    public void Run([EventHubTrigger("bgzeneventhubsub", Connection = "EventHubConnection")] EventData[] events)
    {
        var connectionString = _configuration["EventHubConnection"];
        foreach (EventData @event in events)
        {
            _logger.LogInformation("Event Body: {body}", @event.Body);
            _logger.LogInformation("Event Content-Type: {contentType}", @event.ContentType);
            foreach (var eventData in events)
            {
                string body = eventData.EventBody.ToString();

                _logger.LogInformation("Event Body: {Body}",body);

                _logger.LogInformation("Content Type: {ContentType}",eventData.ContentType);

                _logger.LogInformation("Message Id: {MessageId}",eventData.MessageId);
            }

        }
    }
}