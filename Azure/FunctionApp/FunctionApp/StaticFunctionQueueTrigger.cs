using System;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public static class StaticFunctionQueueTrigger
    {
        private static string apiurl = System.Environment.GetEnvironmentVariable("ApiUrl");

        [Function("StaticFunctionQueueTrigger")]
        [QueueOutput("outqueue")]
        public static string Run(
            //[QueueTrigger("ajs-queue-items", Connection = "ajsQueueStorage")] string myQueueItem,
            //[QueueTrigger("ajs-queue-items", Connection = "AzureWebJobsStorage")] string myQueueItem,
            [QueueTrigger("%input-queue-2%", Connection = "AzureWebJobsStorage")] string myQueueItem,
        FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("StaticFunctionQueueTrigger");
            logger.LogInformation($"StaticFunctionQueueTrigger function processed: {myQueueItem}");
            //myQueueItemCopy = myQueueItem;

            string message = $"{apiurl} : {myQueueItem}";
            return message;
        }
    }
}
