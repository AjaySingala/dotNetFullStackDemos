using StandardEntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateCustomer(1, "John", "Smith", "Reston");
            CreateCustomer(1, "Mary", "Jane", "NYC");
            CreateCustomer(1, "Peter", "Quill", "Boston");
            CreateCustomer(1, "Gus", "Sweet Tooth", "Dallas");
            CreateCustomer(1, "Angela", "Credence", "Los Angeles");
            GetCustomers();
        }

        static void GetCustomers()
        {
            CustomerDbContext db = new CustomerDbContext();
            var customers = db.Customers.ToList();
            foreach(var customer in customers)
            {
                Console.WriteLine($"Id: {customer.Id} | Name: {customer.Firstname} {customer.Lastname} City: {customer.City}");
            }
        }

        static void CreateCustomer(int id, string fname, string lastname, string city)
        {
            Customer customer = new Customer
            {
                Id = 1,
                Firstname = fname,
                Lastname = lastname,
                City = city
            };

            CustomerDbContext db = new CustomerDbContext();
            var customers = db.Customers.Add(customer);
            db.SaveChanges();
        }
    }
}
