// install-package Azure.Messaging.ServiceBus

using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp.Framing;
using System;

namespace QueueSender
{
    internal class Program
    {
        static string _sbConnectionString = "<service bus connection string>";
        static string _queue = "ajsqueueone";

        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            const int numberOfMessages = 5;

            Console.WriteLine("================================================");
            Console.WriteLine("Press any key to exit after sending the message.");
            Console.WriteLine("================================================");

            //SendMessages(3);
            //ReceiveMessages();
            SendMessageBatch();

            Console.ReadKey();
        }

        static async Task SendMessages(int numberOfMessages)
        {
            Console.WriteLine();
            Console.WriteLine("SendMessages()...");

            // Number of messages to be sent to the queue.
            const int numOfMessages = 3;
            try
            {
                //var clientOptions = new ServiceBusClientOptions()
                //{
                //    TransportType = ServiceBusTransportType.AmqpWebSockets
                //};

                // The client that owns the connection and can be used to create senders and receivers.
                //ServiceBusClient client = new ServiceBusClient(_sbConnectionString, clientOptions);
                ServiceBusClient client = new ServiceBusClient(_sbConnectionString);

                // The sender used to publish messages to the queue.
                ServiceBusSender sender = client.CreateSender(_queue);

                for (int i = 1; i <= numOfMessages; i++)
                {
                    var messageBody = $"Message #{i}";
                    // Write the body of the message to the console
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Try sending a message to the queue.
                    var message = new ServiceBusMessage($"{messageBody}");

                    // Send the message to the queue
                    await sender.SendMessageAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {ex.Message}");
            }
        }

        static async Task ReceiveMessages()
        {
            Console.WriteLine();
            Console.WriteLine("ReceiveMessages()...");

            try
            {
                // Service Bus client.
                ServiceBusClient client = new ServiceBusClient(_sbConnectionString);

                // Create a receiver that we can use to receive the message
                ServiceBusReceiver receiver = client.CreateReceiver(_queue);

                // The received message is a different type as it contains some service set properties.
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // Get the message body as a string.
                string body = receivedMessage.Body.ToString();
                Console.WriteLine($"Received message: {body}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {ex.Message}");
            }
        }

        static async Task SendMessageBatch()
        {
            Console.WriteLine();
            Console.WriteLine("SendMessageBatch()...");

            // Number of messages to be sent to the queue.
            const int numOfMessages = 4;
            var clientOptions = new ServiceBusClientOptions()
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };
            // The client that owns the connection and can be used to create senders and receivers.
            ServiceBusClient client = new ServiceBusClient(_sbConnectionString, clientOptions);
            // The sender used to publish messages to the queue.
            ServiceBusSender sender = client.CreateSender(_queue);

            // Start a new batch.
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            for (int i = 1; i <= numOfMessages; i++)
            {
                var msg = new ServiceBusMessage($"Message #{i} Batch");
                Console.WriteLine($"Sending message {msg.Body}...");

                // try adding a message to the batch
                if (!messageBatch.TryAddMessage(msg))
                {
                    // If it is too large for the batch.
                    throw new Exception($"The message '{msg.Body}' is too large to fit in the batch.");
                }
            }

            try
            {
                // Use the producer client to send the batch of messages to the Service Bus queue.
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A batch of {numOfMessages} messages has been published to the queue.");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}