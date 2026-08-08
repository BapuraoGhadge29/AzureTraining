using Azure;
using Azure.Messaging;
using Azure.Messaging.EventGrid;

var endpoint =
    new Uri("https://bankingeventgridtopic.southeastasia-1.eventgrid.azure.net/api/events");

var credential =
    new AzureKeyCredential("CXgKEHgFnfNVzAlm65rsTy54rbYUxGPzkq2UGbABN5AT8K9C0cIOJQQJ99CHACqBBLyXJ3w3AAABAZEG2OWB");

var client =
    new EventGridPublisherClient(endpoint, credential);


var transactionEvent = new
{
    TransactionId = Guid.NewGuid().ToString(),
    AccountNumber = "ACC10001",
    Amount = 50000,
    TransactionType = "Transfer",
    TransactionDate = DateTime.UtcNow
};

var eventGridEvent = new EventGridEvent(
    subject: "Banking/Transaction",
    eventType: "TransactionCreated",
    dataVersion: "1.0",
    data: transactionEvent);

await client.SendEventAsync(eventGridEvent);

Console.WriteLine("Transaction Event Published");