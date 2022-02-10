using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Services
{
    public class MyDependencyLogger : IMyDependency
    {
        private readonly ILogger<MyDependencyLogger> _logger;

        public MyDependencyLogger(ILogger<MyDependencyLogger> logger)
        {
            _logger = logger;
        }

        public void WriteMessage(string message)
        {
            _logger.LogInformation($"MyDependencyLogger.WriteMessage Message: {message}");
        }
    }
}
