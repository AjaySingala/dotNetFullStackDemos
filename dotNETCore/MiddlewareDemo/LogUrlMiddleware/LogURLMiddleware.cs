using Microsoft.Extensions.Logging;

namespace LogUrlMiddleware
{
    public class LogURLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogURLMiddleware> _logger;

        public LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LogURLMiddleware>() ??
                throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;
            request.EnableBuffering();

            _logger.LogInformation($"Request URL: " +
                $"{Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");

            var requestTime = DateTime.Now;
            var requestBody = await GetRequestBody(request);
            var originalBodyStream = response.Body;

            request.Body.Position = 0;
            using (var responseBody = new MemoryStream())
            {
                response.Body = responseBody;

                await _next(context);

                responseBody.Position = 0;
                var responseTime = DateTime.Now;
                //var responseBodyString = await GetResponseBody(response);
                var responseBodyString = new StreamReader(responseBody).ReadToEnd();
                responseBody.Position = 0;

                await responseBody.CopyToAsync(originalBodyStream);

                _logger.LogInformation($"LogURLMiddleware: " +
                    $"Request: {requestTime} {request.Method} {request.Scheme}" +
                    $"://{request.Host}{request.Path} {request.QueryString} {requestBody}" +
                    $"Response: {responseTime} {response.StatusCode} {responseBodyString}");
            }
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            var stream = new StreamReader(request.Body);
            var body = await stream.ReadToEndAsync();
            return body;
        }
    }
}
