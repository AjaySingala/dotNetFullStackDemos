using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogConsoleApp01
{
    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _log;
        private readonly IConfiguration _config;
        public DataService(ILogger<DataService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void Connect()
        {
            // Connect to the database
            var connectionString = _config.GetValue<string>("ConnectionStrings:DefaultConnection");

            _log.LogDebug("Connection String {cs}", connectionString);
            _log.LogInformation("Connection String {cs}", connectionString);
            _log.LogWarning("Connection String {cs}", connectionString);
            _log.LogError("Connection String {cs}", connectionString);
            _log.LogCritical("Connection String {cs}", connectionString);

            try
            {
                throw new Exception("Testing exception logging with Serilog.");
            }
            catch(Exception ex)
            {
                _log.LogError(ex, "ERROR!");
            }
        }
    }
}

