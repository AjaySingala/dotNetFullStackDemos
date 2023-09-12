using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DurableFunctionApp
{
    public static class SubmitOrder
    {
        [FunctionName("SubmitOrder")]
        [return: ServiceBus("orders", ServiceBusEntityType.Queue)]
        public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "order")]
                HttpRequest req,
                //[ServiceBus("orders", Connection = "ServiceBusConnectionString")] out Message outMessage,
                ILogger log)
        {
            string orderAsJson = new StreamReader(req.Body).ReadToEnd();
            dynamic order = JsonConvert.DeserializeObject(orderAsJson);
            string orderNumber = order?.orderNumber;
            string correlationId = Guid.NewGuid().ToString();
            order.correlationId = correlationId;

            if (IsOrderValid(order))
            {
                //outMessage = new Message(Encoding.ASCII.GetBytes(orderAsJson));
                //// Set the Service Bus Message CorrelationId property for correlation in the subscriber function
                //outMessage.CorrelationId = correlationId;

                Message outMessage = new Message(Encoding.ASCII.GetBytes(orderAsJson));
                // Set the Service Bus Message CorrelationId property for correlation in the subscriber function
                outMessage.CorrelationId = correlationId;

                log.LogInformation(new EventId((int)LoggingConstants.EventId.SubmissionSucceeded),
                                    LoggingConstants.Template,
                                    LoggingConstants.EventId.SubmissionSucceeded.ToString(),
                                    LoggingConstants.EntityType.Order.ToString(),
                                    orderNumber,
                                    LoggingConstants.Status.Succeeded.ToString(),
                                    correlationId,
                                    LoggingConstants.CheckPoint.Publisher.ToString(),
                                    "");

                //return new OkResult();
                var msg = outMessage.ToString();
                return new OkObjectResult(order);
            }
            else
            {
                log.LogError(new EventId((int)LoggingConstants.EventId.SubmissionFailed),
                                    LoggingConstants.Template,
                                    LoggingConstants.EventId.SubmissionFailed.ToString(),
                                    LoggingConstants.EntityType.Order.ToString(),
                                    orderNumber,
                                    LoggingConstants.Status.Failed.ToString(),
                                    correlationId,
                                    LoggingConstants.CheckPoint.Publisher.ToString(),
                                    "Order is not valid and cannot be sent for processing.");

                //outMessage = null;
                return new BadRequestObjectResult("Order is not Valid");
            }
        }

        /// <summary>
        /// Returns whether an Order is Valid or not based on a random number
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private static bool IsOrderValid(object order)
        {
            Random random = new Random();
            return random.Next(0, 5) == 4 ? false : true;
        }
    }
}