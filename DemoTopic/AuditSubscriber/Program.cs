﻿using Azure.Messaging.ServiceBus;

string connectionString =
 "Endpoint=sb://bgzensb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Ffba14sYplnHpqGPPdWfWo7SmJiBYMHhr+ASbHeDciE=";

await using var client =
 new ServiceBusClient(connectionString);

var processor =
 client.CreateProcessor(
 "transactiotopic",
 "auditsubscription");

processor.ProcessMessageAsync +=
async args =>
{
    Console.WriteLine();

    Console.WriteLine(
      "Audit Record Saved");

    Console.WriteLine(
      args.Message.Body.ToString());

    await args.CompleteMessageAsync(
      args.Message);
};

processor.ProcessErrorAsync += args =>
{
    Console.WriteLine(args.Exception);

    return Task.CompletedTask;
};

await processor.StartProcessingAsync();

Console.WriteLine(
    "Press any key to end the processing");

Console.ReadKey();
await processor.StopProcessingAsync();