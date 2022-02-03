
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace SerilogConsoleApp01
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Serilog Demo....");
            var host = AppStartup();
            var service = ActivatorUtilities.CreateInstance<DataService>(host.Services);
            service.Connect();

        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            // Check the current directory that the application is running on 
            // Then once the file 'appsetting.json' is found, we are adding it.
            // We add env variables, which can override the configs in appsettings.json
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            // Specifying the configuration for serilog
            Log.Logger = new LoggerConfiguration() // initiate the logger configuration
                            .ReadFrom.Configuration(builder.Build()) // connect serilog to our configuration folder
                            .Enrich.FromLogContext() //Adds more information to our logs from built in Serilog 
                            .WriteTo.Console() // decide where the logs are going to be shown
                            //.WriteTo.File("logs/logfile.log")
                            //.WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Error)

                            //// For Enricher:
                            //.Enrich.With(new ThreadIdEnricher())
                            //.WriteTo.Console(
                            //    outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}"
                            //)

                            .CreateLogger(); //initialise the logger

            Log.Logger.Information("Application Starting");

            // Initialising the Host 
            var host = Host.CreateDefaultBuilder()
                        // Adding the DI container for configuration
                        .ConfigureServices((context, services) =>
                        {
                            // Add transient mean give me an instance each time it is being requested.
                            services.AddTransient<IDataService, DataService>();
                        })
                        .UseSerilog() // Add Serilog
                        .Build(); // Build the Host

            return host;
        }
    }
}