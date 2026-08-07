using DemoQueStorage.Services;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config["ConnectionStrings:cs"]!;

        var queueService = new QueueService(connectionString);

        // Create dynamic message
        string message =
            $"Message_{DateTime.Now:yyyyMMdd_HHmmss}";

        Console.WriteLine($"Sending Message: {message}");

        // Send Message
        await queueService.SendMessageAsync(message);

        // Peek Messages
        Console.WriteLine("\nPeeking Messages:");
        await queueService.PeekMessagesAsync();

        // Get Queue Count
        Console.WriteLine("\nQueue Details:");
        await queueService.GetQueueLengthAsync();

        // Receive and Delete Message
        Console.WriteLine("\nReceiving and Deleting Message:");
        await queueService.ReceiveAndDeleteMessageAsync();

        Console.WriteLine("\nQueue operation completed.");
    }
}