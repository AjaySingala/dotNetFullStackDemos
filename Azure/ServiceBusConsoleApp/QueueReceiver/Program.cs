using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

Console.WriteLine();
Console.WriteLine("QueueReceiver...");

int msgCount = 0;

// The client that owns the connection and can be used to create senders and receivers.
ServiceBusClient client;

// The processor that reads and processes messages from the queue.
ServiceBusProcessor processor;

// Handle received messages.
async Task MessageHandler(ProcessMessageEventArgs args)
{
    msgCount++;
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Received: {body}");

    // Complete the message. Message is deleted from the queue.
    await args.CompleteMessageAsync(args.Message);
}

// Handle any errors when receiving messages.
Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}

// The Service Bus client types are safe to cache and use as a singleton for the lifetime
// of the application, which is best practice when messages are being published or read
// regularly.
//
// Set the transport type to AmqpWebSockets so that the ServiceBusClient uses port 443. 
// If you use the default AmqpTcp, make sure that ports 5671 and 5672 are open.

// TODO: Replace the <NAMESPACE-CONNECTION-STRING> and <QUEUE-NAME> placeholders
string _sbConnectionString = "<service bus connection string>";
string _queue = "ajsqueueone";

var clientOptions = new ServiceBusClientOptions()
{
    TransportType = ServiceBusTransportType.AmqpWebSockets
};
client = new ServiceBusClient(_sbConnectionString, clientOptions);

// Create a processor that we can use to process the messages.
// TODO: Replace the <QUEUE-NAME> placeholder
processor = client.CreateProcessor(_queue, new ServiceBusProcessorOptions());

try
{
    // Add handler to process messages.
    processor.ProcessMessageAsync += MessageHandler;

    // Add handler to process any errors.
    processor.ProcessErrorAsync += ErrorHandler;

    // Start processing.
    await processor.StartProcessingAsync();

    Console.WriteLine("Wait for a minute and then press any key to end the processing");
    Console.ReadKey();

    // Stop processing 
    Console.WriteLine("\nStopping the receiver...");
    Console.WriteLine($"{msgCount} messages received.");
    await processor.StopProcessingAsync();
    Console.WriteLine("Stopped receiving messages");
}
finally
{
    // Calling DisposeAsync on client types is required to ensure that network
    // resources and other unmanaged objects are properly cleaned up.
    await processor.DisposeAsync();
    await client.DisposeAsync();
}
