using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace DemoQueStorage.Services
{
    public class QueueService
    {
        private readonly string _connectionString;
        private const string QueueName = "orders";

        public QueueService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Create Queue if not exists
        private async Task<QueueClient> GetQueueClientAsync()
        {
            QueueClient queueClient =
                new QueueClient(_connectionString, QueueName);

            await queueClient.CreateIfNotExistsAsync();

            return queueClient;
        }

        // Add Message
        public async Task SendMessageAsync(string message)
        {
            QueueClient queueClient =
                await GetQueueClientAsync();

            await queueClient.SendMessageAsync(message);

            Console.WriteLine($"Message Sent: {message}");
        }

        // Read Message (without deleting)
        public async Task PeekMessagesAsync()
        {
            QueueClient queueClient =
                await GetQueueClientAsync();

            PeekedMessage[] messages =
                await queueClient.PeekMessagesAsync(maxMessages: 10);

            foreach (var message in messages)
            {
                Console.WriteLine($"Message: {message.MessageText}");
            }
        }

        // Receive and Delete Message
        public async Task ReceiveAndDeleteMessageAsync()
        {
            QueueClient queueClient =
                await GetQueueClientAsync();

            QueueMessage[] messages =
                await queueClient.ReceiveMessagesAsync(
                    maxMessages: 1,
                    visibilityTimeout: TimeSpan.FromSeconds(30));

            foreach (var message in messages)
            {
                Console.WriteLine($"Received: {message.MessageText}");

                await queueClient.DeleteMessageAsync(
                    message.MessageId,
                    message.PopReceipt);

                Console.WriteLine("Message Deleted");
            }
        }

        // Get Queue Properties
        public async Task GetQueueLengthAsync()
        {
            QueueClient queueClient =
                await GetQueueClientAsync();

            QueueProperties properties =
                await queueClient.GetPropertiesAsync();

            Console.WriteLine(
                $"Approximate Messages Count: {properties.ApproximateMessagesCount}");
        }
    }
}