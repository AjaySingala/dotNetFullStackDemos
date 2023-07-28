// # Isolated option selected.

using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;


namespace FunctionApp
{
    public class MultiResponse
    {
        [QueueOutput("outqueue", Connection = "AzureWebJobsStorage")]
        public string[] Messages { get; set; }
        public HttpResponseData HttpResponse { get; set; }
    }

    public class HttpExample
    {
        private readonly ILogger _logger;

        public HttpExample(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpExample>();
        }

        #region HttpExample Simple (without Queue Trigger).
        // Remember to comment out the Run function below and uncomment this one.

        //[Function("HttpExample")]
        //public HttpResponseData Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        //    FunctionContext executionContext)
        //{
        //    //var logger = executionContext.GetLogger("HttpExample");
        //    _logger.LogInformation("C# HTTP trigger function processed a request.");

        //    var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
        //    string name = query["Name"];

        //    var response = req.CreateResponse(HttpStatusCode.OK);
        //    response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        //    string message = $"Welcome to Azure Functions!" +
        //        $" Hello, {name}. This HTTP triggered function executed successfully.";
        //    response.WriteString(message);

        //    return response;
        //}

        #endregion

        #region HttpExample Simple (with Queue Trigger).
        // Remember to comment out the Run function above and uncomment this one.

        [Function("HttpExample")]
        //public static HttpResponseData Run(
        public static MultiResponse Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("HttpExample");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
            string name = query["Name"];
            //string name = req.FunctionContext.BindingContext.BindingData["name"].ToString();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            string message = $"Welcome to Azure Functions!" +
                $" Hello, {name}. This HTTP triggered function executed successfully.";
            response.WriteString(message);

            //return response;
            // Return a response to both HTTP trigger and storage output binding.
            return new MultiResponse()
            {
                // Write a single message.
                Messages = new string[] { message },
                HttpResponse = response
            };
        }

        #endregion
    }
}
