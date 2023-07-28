using System;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class FunctionQueueTrigger
    {
        //[Function("FunctionQueueTrigger")]
        //public void Run([QueueTrigger("ajs-queue-items", Connection = "ajsQueueStorage")] string myQueueItem)
        //{
        //    _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        //}

        [Function("FunctionQueueTrigger")]
        //public static MultiResponse Run(
        [QueueOutput("outqueue")]
        public static string Run(
            //[QueueTrigger("ajs-queue-items", Connection = "ajsQueueStorage")] string myQueueItem,
            [QueueTrigger("ajs-queue-items", Connection = "AzureWebJobsStorage")] string myQueueItem,
        FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("FunctionQueueTrigger");
            logger.LogInformation($"FunctionQueueTrigger function processed: {myQueueItem}");
            //myQueueItemCopy = myQueueItem;

            string message = $"{myQueueItem}";
            // Put the message recd. in the output queue.
            //return new MultiResponse()
            //{
            //    // Write a single message.
            //    Messages = new string[] { message }
            //};
            return message;
        }
    }
}
