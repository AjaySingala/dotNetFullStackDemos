using EFDBFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Entity;

namespace EFDBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetCustomers();
            //CreateCustomer(101, "Leanne", "Graham", "Reston");
            //CreateCustomer(102, "Ervin", "Howell", "NYC");
            //CreateCustomer(103, "Clementine", "Bauch", "Boston");
            //CreateCustomer(104, "Patricia", "Lebsack", "Dallas");
            //CreateCustomer(105, "Clementina", "DuBuque", "Los Angeles");

            //UpdateCustomer();
            //GetCustomers();

            //DeleteCustomer();
            //GetCustomers();

            //CreateCustomerWithState(999, "Added", "State", "Nowhere");
            //GetCustomers();

            // Relationships.
            //GetGrades();

        }

        #region Customers

        static void GetCustomers()
        {
            Console.WriteLine("\nGetCustomers");
            CustomerDbContext db = new CustomerDbContext();
            var customers = db.Customers.ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.Id} | Name: {customer.Firstname} {customer.Lastname} City: {customer.City}");
            }
        }

        static void CreateCustomer(int id, string fname, string lastname, string city)
        {
            Console.WriteLine("\nCreateCustomer");
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

        static void UpdateCustomer()
        {
            Console.WriteLine("\nUpdateCustomer");

            CustomerDbContext db = new CustomerDbContext();
            var customer = db.Customers
                .Where(c => c.Id == 1)
                .FirstOrDefault<Customer>();
            customer.City = "Miami";
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        static void DeleteCustomer()
        {
            Console.WriteLine("\nDeleteCustomer");
            CreateCustomer(999, "Temp", "Data", "Garbage");
            GetCustomers();
            Console.WriteLine("\nDeleting...");

            CustomerDbContext db = new CustomerDbContext();
            var customer = db.Customers
                .Where(c => c.Firstname == "Temp")
                .FirstOrDefault<Customer>();
            db.Entry(customer).State = EntityState.Deleted;
            db.SaveChanges();
        }

        static void CreateCustomerWithState(int id, string fname, string lastname, string city)
        {
            Console.WriteLine("\nCreateCustomerWithState");
            Customer customer = new Customer
            {
                Id = 1,
                Firstname = fname,
                Lastname = lastname,
                City = city
            };

            CustomerDbContext db = new CustomerDbContext();
            db.Entry(customer).State = EntityState.Added;
            db.SaveChanges();
        }

        #endregion

    }
}
