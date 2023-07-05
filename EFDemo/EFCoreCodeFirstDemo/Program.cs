using EFCoreCodeFirstDemo.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCoreCodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateData();
            GetCustomers();
        }

        static void CreateData()
        {
            //CreateCustomer();
            //CreateAddress();
        }

        static void GetCustomers()
        {
            Console.WriteLine();
            Console.WriteLine("GetCustomers()...");

            var db = new CodeFirstDbContext();
            var customers = db.Customers.ToList();
            foreach(var customer in customers)
            {
                Console.WriteLine($"{customer.Id}" +
                    $" | {customer.Firstname}" +
                    $" | {customer.Lastname}");

                db.Entry(customer).Collection(c => c.Addresses).Load();
                foreach(var address in customer.Addresses)
                {
                    Console.WriteLine($"\t{address.Id}" +
                        $" | {address.City}");
                }
            }

        }
    }
}