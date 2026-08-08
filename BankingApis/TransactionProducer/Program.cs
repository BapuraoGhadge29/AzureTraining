using Azure;
using Azure.Messaging.EventGrid;

string endpoint ="https://bgzenbankingtransactiontopic.southeastasia-1.eventgrid.azure.net/api/events";

string key ="4T8R1unFd3LMRvew5o5L4RTAj4cnkOdql1Pioj5VmIKwpQ7qgmOtJQQJ99CHACqBBLyXJ3w3AAABAZEG2EE6";

var client = new EventGridPublisherClient(new Uri(endpoint),new AzureKeyCredential(key));

var transaction = new
{
    transactionId = Guid.NewGuid(),
    charustomerName = "Bapurao Ghadge",
    accountNumber = "1234567890",
    amount = 50000,
    transactionDate = DateTime.UtcNow,
    transactionType = "Transfer"
};

EventGridEvent evt = new EventGridEvent("Bank.Transaction","Transaction.Created","1.0",transaction);

await client.SendEventAsync(evt);

Console.WriteLine("Transaction Event Published");
