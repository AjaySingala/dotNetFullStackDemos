using EFDemoCore.Entities;
using EFDemoCore.Entities.TempEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Transactions;

namespace EFDemoCore
{
    internal class Program
    {
        static IConfigurationRoot _config;
        static string _nwConnectionString = "";

        static void Main(string[] args)
        {
            // Build a config object, using env vars and JSON providers.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json");
                //.AddEnvironmentVariables();

            var services = new ServiceCollection();
            _config = builder.Build();
            ReadConfig();

            //services.AddDbContext<NWDbContext>(
            //    options => options.UseSqlServer(_nwConnectionString));

            //GetCustomers();
            //CreateOrder("ALFKI");
            //DeleteOrder();

            CreateAddress();
            DeleteTempCustomer();

            //XDbTxn();
        }

        static void XDbTxn()
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var db1 = new NWDbContext();
                    //using (var txn = db1.Database.BeginTransaction())
                    {
                        try
                        {
                            db1.Customers.Add(new Entities.Customer
                            {
                                CustomerId = "XYZAB",
                                CompanyName = "XYZAB",
                                ContactName = "XYZAB",
                                City = "Reston"
                            });
                            db1.SaveChanges();

                            var db2 = new TempDbContext();
                            //db2.Database.UseTransaction(txn.GetDbTransaction());

                            db2.Customers.Add(new EFDemoCore.Entities.TempEntities.Customer
                            { FirstName = "johnny", LastName = "stills", City = "Reston" }
                            );

                            db2.SaveChanges();

                            // This should throw an exception!
                            db2.Customers.Where(c => c.Id == 1 || c.Id == 2)
                                .SingleOrDefault();

                            //txn.Commit();
                        }
                        catch (Exception ex)
                        {
                            //txn.Rollback();
                            Console.WriteLine("ROLLING BACK!!!");
                            Console.WriteLine(ex.ToString());
                            throw;
                        }
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SCOPE INCOMPLETE!!!");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void ReadConfig()
        {
            Console.WriteLine();
            Console.WriteLine("ReadConfig()...");

            _nwConnectionString = _config.GetConnectionString("northwind");

            Settings settings = _config.GetRequiredSection("Settings").Get<Settings>();
            // Write the values to the console.
            Console.WriteLine($"KeyOne = {settings?.KeyOne}");
            Console.WriteLine($"KeyTwo = {settings?.KeyTwo}");
            Console.WriteLine($"KeyThree:Message = {settings?.KeyThree?.Message}");

            var connStrN = _config.GetConnectionString("northwind");
            var connStrP = _config.GetConnectionString("pubs");
            Console.WriteLine($"Northwind Connection String: {connStrN}");
            Console.WriteLine($"Pubs Connection String: {connStrP}");

            var ipOne = _config["IPAddressRange:0"];
            Console.WriteLine($"{ipOne}");
            Console.WriteLine($"{_config["IPAddressRange:1"]}");
            Console.WriteLine($"{_config["IPAddressRange:2"]}");
        }

        static void CreateAddress()
        {
            using (var db = new TempDbContext())
            {
                var customer = db.Customers.Find(13);

                var address1 = new Address
                {
                    AddressLine1 = "Line 1",
                    AddressLine2 = "Line 2",
                    City = "City",
                    CustomerId = customer.Id,
                    Customer = customer

                };

                db.Addresses.Add(address1);
                db.SaveChanges();
            }
        }

        static void DeleteTempCustomer()
        {
            using (var db = new TempDbContext())
            {
                var customer = db.Customers
                    .Include(c => c.Addresses)
                    .Where(c => c.Id == 13)
                    .FirstOrDefault();
                db.Remove(customer);
                db.SaveChanges();
            }
        }

        static void GetCustomers()
        {
            Console.WriteLine();
            Console.WriteLine("CreateOrder()...");

            using (var db = new NWDbContext())
            {
                var customers = db.Customers.ToList();
            }
        }

        static void CreateOrder(string customerId)
        {
            Console.WriteLine();
            Console.WriteLine("CreateOrder()...");

            using (var db = new NWDbContext())
            {
                var customer = db.Customers.Find(customerId);
                var employee = db.Employees.Find(3);

                var order = new Order
                {
                    CustomerId = customerId,
                    Customer = customer,
                    EmployeeId = employee.EmployeeId,
                    Employee = employee,
                    OrderDate = DateTime.Now.Date,
                    ShipName = "Some Ship Name",
                    ShipCity = "Dallas"
                };

                var prod1 = db.Products.Find(4);
                var prod2 = db.Products.Find(5);
                var prod3 = db.Products.Find(6);

                #region Long Code.

                //var details = new List<OrderDetail>();
                //var prodDetail1 = new OrderDetail
                //{
                //    OrderId = order.OrderId,
                //    ProductId = prod1.ProductId,
                //    Quantity = 10,
                //    UnitPrice = prod1.UnitPrice
                //};
                //details.Add(prodDetail1);
                //var prodDetail2 = new OrderDetail
                //{
                //    OrderId = order.OrderId,
                //    ProductId = prod2.ProductId,
                //    Quantity = 5,
                //    UnitPrice = prod2.UnitPrice
                //};
                //details.Add(prodDetail2);
                //var prodDetail3 = new OrderDetail
                //{
                //    OrderId = order.OrderId,
                //    ProductId = prod3.ProductId,
                //    Quantity = 7,
                //    UnitPrice = prod3.UnitPrice
                //};
                //details.Add(prodDetail3);

                #endregion

                var details = new List<OrderDetail>
                {
                    new OrderDetail {
                        OrderId = order.OrderId,
                        ProductId = prod1.ProductId,
                        Quantity = 10,
                        UnitPrice = prod1.UnitPrice,
                        Order = order,
                        Product = prod1
                    },
                    new OrderDetail {
                        OrderId = order.OrderId,
                        ProductId = prod2.ProductId,
                        Quantity = 5,
                        UnitPrice = prod2.UnitPrice,
                        Order = order,
                        Product = prod2
                    },
                    new OrderDetail {
                        OrderId = order.OrderId,
                        ProductId = prod3.ProductId,
                        Quantity = 7,
                        UnitPrice = prod3.UnitPrice,
                        Order = order,
                        Product = prod3
                    }
                };

                //prod1.UnitsInStock -= 10;
                //prod2.UnitsInStock -= 5;
                //prod3.UnitsInStock -= 7;

                //// To update/delete a product's stock explicitly.
                //prod1 = db.Products.Find(1);
                ////prod1.UnitsInStock -= 10;

                ////db.Entry(prod1).State = EntityState.Modified;
                //// OR
                //db.Entry(prod1).State = EntityState.Deleted;
                //db.Products.Remove(prod1);
                //db.SaveChanges();

                using (var txn = db.Database.BeginTransaction())
                {
                    try
                    {
                        order.OrderDetails = details;

                        db.Orders.Add(order);
                        db.SaveChanges();

                        //db.OrderDetails.Add(prodDetail1);
                        //db.OrderDetails.Add(prodDetail2);
                        //db.OrderDetails.Add(prodDetail3);
                        // OR
                        //db.OrderDetails.AddRange(details);
                        //db.SaveChanges();

                        txn.Commit();
                    }
                    catch (Exception ex)
                    {
                        txn.Rollback();
                        Console.WriteLine($"ERROR! {ex.ToString()}");
                    }
                }
            }
        }

        static void DeleteOrder()
        {
            Console.WriteLine();
            Console.WriteLine("DeleteOrder()...");

            using (var db = new NWDbContext())
            {
                var ordersToDelete = db.Orders
                    //.Include(o => o.OrderDetails)         // Cascade Deletes.
                    .Where(o => o.OrderId > 11079)
                    .ToList();
                db.Orders.RemoveRange(ordersToDelete);
                db.SaveChanges();
            }
        }
    }
}
