using FirstCoreAppConsole.Entities;
using Microsoft.Extensions.Configuration;

namespace FirstCoreAppConsole
{
    internal class Program
    {
        static IConfigurationRoot _config;

        static void Main(string[] args)
        {
            // Build a config object, using env vars and JSON providers.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json");
            var _config = builder.Build();

            //ReadConfig();
            //GetNWCustomers();

            //GetECCustomers();

        }

        static void ReadConfig()
        {
            Settings settings = _config.GetRequiredSection("Settings").Get<Settings>();
            // Write the values to the console.
            Console.WriteLine($"KeyOne = {settings?.KeyOne}");
            Console.WriteLine($"KeyTwo = {settings?.KeyTwo}");
            Console.WriteLine($"KeyThree:Message = {settings?.KeyThree?.Message}");

            var ipOne = _config["IPAddressRange:0"];
            Console.WriteLine($"{ipOne}");
            Console.WriteLine($"{_config["IPAddressRange:1"]}");
            Console.WriteLine($"{_config["IPAddressRange:2"]}");

        }

        //static void GetNWCustomers()
        //{
        //    NWDbContext db = new NWDbContext();
        //    var customers = db.Customers.ToList();
        //    foreach (var customer in customers)
        //    {
        //        Console.WriteLine($"{customer.ContactName}");
        //    }
        //}

        //static void GetECCustomers()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("GetECCustomers()...");

        //    using(var db = new ECommerceDbContext())
        //    {
        //        var customers = db.Customers.ToList();
        //        foreach (var customer in customers)
        //        {
        //            Console.WriteLine($"{customer.ContactName}");
        //        }
        //    }
        //}
    }
}