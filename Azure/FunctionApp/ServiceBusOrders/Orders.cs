using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ServiceBusOrders
{
    public class Orders
    {
        [FunctionName("SubmitOrder")]
        public static IActionResult Submit(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "order")]
            HttpRequest req,
            [ServiceBus("orders", Connection = "AzureWebJobsServiceBus")] out Message outMessage,
            ILogger log)
        {
            //log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            string orderAsJson = new StreamReader(req.Body).ReadToEnd();
            dynamic order = JsonConvert.DeserializeObject(orderAsJson);
            string orderNumber = order?.orderNumber;
            string correlationId = Guid.NewGuid().ToString();
            order.correlationId = correlationId;

            outMessage = new Message(Encoding.ASCII.GetBytes(orderAsJson));
            // Set the Service Bus Message CorrelationId property for correlation in the subscriber function
            outMessage.CorrelationId = correlationId;

            log.LogInformation(new EventId((int)LoggingConstants.EventId.SubmissionSucceeded),
                LoggingConstants.Template,
                LoggingConstants.EventId.SubmissionSucceeded.ToString(),
                LoggingConstants.EntityType.Order.ToString(),
                $"Order No.: {orderNumber}",
                LoggingConstants.Status.Succeeded.ToString(),
                $"Correlation Id: {correlationId}",
                LoggingConstants.CheckPoint.Publisher.ToString(),
                                    "");

            return new OkResult();
        }

        [FunctionName("ProcessOrder")]
        public void Process(
            [ServiceBusTrigger("orders", Connection = "AzureWebJobsServiceBus")] string inMessage,
            string correlationId,
            ILogger log)
        {
            //log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            dynamic order = JsonConvert.DeserializeObject(inMessage);
            string orderNumber = order?.orderNumber;
            //string correlationId = order.Value.correlationId;

            //Log a success event if there was no exception. 
            log.LogInformation(new EventId((int)LoggingConstants.EventId.ProcessingSucceeded),
                LoggingConstants.Template,
                LoggingConstants.EventId.ProcessingSucceeded.ToString(),
                LoggingConstants.EntityType.Order.ToString(),
                $"Order No.: {orderNumber}",
                LoggingConstants.Status.Succeeded.ToString(),
                $"Correlation Id: {correlationId}",
                LoggingConstants.CheckPoint.Subscriber.ToString(),
                "");
        }
    }
}
