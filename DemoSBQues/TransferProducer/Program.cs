﻿using Azure.Messaging.ServiceBus;
using System.Text.Json;
using TransferProducer.Models;

string connectionString = "Endpoint=sb://bgzensb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Ffba14sYplnHpqGPPdWfWo7SmJiBYMHhr+ASbHeDciE=";
string queueName = "transferq";

await using var client = new ServiceBusClient(connectionString);

ServiceBusSender sender = client.CreateSender(queueName);

var transferRequest = new TransferRequest
{
    TransactionId = Guid.NewGuid().ToString(),
    AccountFrom = "1234567890",
    AccountTo = "0987654321",
    Amount = 25000.00m,
    CreatedOn = DateTime.UtcNow
};

string json = JsonSerializer.Serialize(transferRequest);
ServiceBusMessage message = new ServiceBusMessage(json);
message.ApplicationProperties.Add("TransactionType", "FundTransfer");

await sender.SendMessageAsync(message);
Console.WriteLine($"Transfer request submitted. Transaction ID: {transferRequest.TransactionId}");