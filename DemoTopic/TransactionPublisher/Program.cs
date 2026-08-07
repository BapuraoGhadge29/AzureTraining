using Azure.Messaging.ServiceBus;
using System.Text.Json;
using SharedModels;
using System.Transactions;

string connectionString =
    "Endpoint=sb://bgzensb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Ffba14sYplnHpqGPPdWfWo7SmJiBYMHhr+ASbHeDciE=";

string topicName =
    "transactiotopic";

await using ServiceBusClient client = new ServiceBusClient(connectionString);

ServiceBusSender sender =
    client.CreateSender(topicName);

var transaction =
    new TransactionEvent
    {
        TransactionId = "5a4b9e79-522b-4288-8efa-707dc3dee5f7",

        CustomerId = "CUST1001",

        FromAccount = "SBI100001",

        ToAccount = "ICICI200001",

        Amount = 25000,

        Channel = "InternetBanking",

        Status = "SUCCESS",

        TransactionTime = DateTime.UtcNow
    };

string messageBody =
    JsonSerializer.Serialize(transaction);

ServiceBusMessage message =
    new ServiceBusMessage(messageBody);

message.MessageId =
    transaction.TransactionId;

message.ApplicationProperties.Add(
    "Amount",
    transaction.Amount);

message.ApplicationProperties.Add(
    "Channel",
    transaction.Channel);

await sender.SendMessageAsync(message);

Console.WriteLine(
    $"Transaction Published : {transaction.TransactionId}");

