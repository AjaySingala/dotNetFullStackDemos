using EFDemo.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetAllCustomers();
            //GetAllOrders();
            //GetCustomer("ABCRP");
            //GetCustomer("BOTTM");
            //GetCustomer("PICCO");
            //GetCustomer("XYZAB");
            //GetCustomersByCity("Madrid");
            //GetCustomersByCity("Berlin");
            //GetCustomersByCity("London");
            //GetCustomersByCity("Mumbai");
            //GetCustomersByCity("");

            //FindCustomer("ALFKI");
            //FindCustomer("BERGS");
            //FindCustomer("ABCDE");

            //FindEmployee(1);
            //FindEmployee(7);

            //SelectColumn();
            //QueryProjectionDemo();
            //LikeOperatorDemo("Ana");
            //LikeOperatorDemo("min");
            //LikeOperatorDemo("ers");

            //GetCustomerQuerySyntax();

            //GetOrders("ALFKI");
            //GetOrders("ABCDE");

            //ExplicitLoading("ALFKI");

            //CreateCustomer();
            //CreateOrder("ALFKI");

            //CreateRegion();
            DeleteOrder();
        }

        static void GetAllCustomers()
        {
            Console.WriteLine();
            Console.WriteLine("GetAllCustomers()...");

            NWDbContext ctx = new NWDbContext();
            foreach (Customer cust in ctx.Customers)
            {
                Console.WriteLine($"{cust.CustomerId}" +
                    $" | {cust.CompanyName}" +
                    $" | {cust.ContactName}" +
                    $" | {cust.City}");
            }
        }

        static void GetAllOrders()
        {
            Console.WriteLine();
            Console.WriteLine("GetAllOrders()...");

            NWDbContext ctx = new NWDbContext();
            foreach (var order in ctx.Orders)
            {
                Console.WriteLine($"{order.OrderId}" +
                    $" | {order.OrderDate}" +
                    $" | {order.CustomerId}" +
                    $" | {order.EmployeeId}" +
                    $" | {order.ShipName}" +
                    $" | {order.ShipCity}");
            }
        }

        static void GetCustomer(string id)
        {
            Console.WriteLine();
            Console.WriteLine("GetCustomer()...");

            NWDbContext ctx = new NWDbContext();

            //Customer customerRecord = new Customer();
            //foreach (Customer cust in ctx.Customers)
            //{
            //    if(cust.CustomerId == id)
            //    {
            //        customerRecord = cust;
            //        break;
            //    }
            //}
            var customer = ctx.Customers
                .Where(abc => abc.CustomerId == id)
                .FirstOrDefault<Customer>();
            if (customer != null)
            {
                Console.WriteLine($"{customer.CustomerId}" +
                    $" | {customer.CompanyName}" +
                    $" | {customer.ContactName}" +
                    $" | {customer.City}");
            }
        }

        static void GetCustomersByCity(string city)
        {
            Console.WriteLine();
            Console.WriteLine("GetCustomersByCity()...");

            NWDbContext ctx = new NWDbContext();

            var customers = ctx.Customers
                .Where(c => c.City == city)
                .ToList<Customer>();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerId}" +
                    $" | {customer.CompanyName}" +
                    $" | {customer.ContactName}" +
                    $" | {customer.City}");
            }
        }

        static void FindCustomer(string customerId)
        {
            Console.WriteLine();
            Console.WriteLine("FindCustomer()...");

            NWDbContext ctx = new NWDbContext();

            var customer = ctx.Customers
                .Find(customerId);
            if (customer != null)
            {
                Console.WriteLine($"{customer.CustomerId}" +
                    $" | {customer.CompanyName}" +
                    $" | {customer.ContactName}" +
                    $" | {customer.City}");
            }
        }

        static void FindEmployee(int empId)
        {
            Console.WriteLine();
            Console.WriteLine("FindEmployee()...");

            NWDbContext ctx = new NWDbContext();

            var emp = ctx.Employees
                .Find(empId);
            if (emp != null)
            {
                Console.WriteLine($"{emp.EmployeeId}" +
                    $" | {emp.Lastname}" +
                    $" | {emp.Firstname}");
            }
        }

        static void SelectColumn()
        {
            Console.WriteLine();
            Console.WriteLine("SelectColumn()...");

            NWDbContext ctx = new NWDbContext();

            var customers = ctx.Customers
                //.Where(c => c.City == "Madrid")
                .Select(c => c.ContactName)
                .ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer}");
            }
        }

        static void QueryProjectionDemo()
        {
            Console.WriteLine();
            Console.WriteLine("QueryProjectionDemo()...");

            NWDbContext ctx = new NWDbContext();

            var customers = ctx.Customers
                //.Select(c => new
                //{
                //    Id = c.CustomerId,
                //    Company = c.CompanyName,
                //    Contact = c.ContactName
                //})
                //.ToList();
                .Select(c => new CustomCustomer
                {
                    Id = c.CustomerId,
                    Company = c.CompanyName,
                    Contact = c.ContactName
                })
                .ToList<CustomCustomer>();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}" +
                    $" | {customer.Company}" +
                    $" | {customer.Contact}");
            }
        }

        static void LikeOperatorDemo(string name)
        {
            Console.WriteLine();
            Console.WriteLine("LikeOperatorDemo()...");

            NWDbContext ctx = new NWDbContext();
            ctx.Database.Log = Console.Write;

            var customers = ctx.Customers
                //.Where(abc => abc.ContactName.Contains(name))
                //.Where(abc => abc.ContactName.StartsWith(name))
                .Where(abc => abc.ContactName.EndsWith(name))
                .ToList<Customer>();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerId}" +
                    $" | {customer.CompanyName}" +
                    $" | {customer.ContactName}" +
                    $" | {customer.City}");
            }
        }

        static void GetCustomerQuerySyntax()
        {
            Console.WriteLine();
            Console.WriteLine("GetCustomerQuerySyntax()...");

            using (var db = new NWDbContext())
            {
                //var customers = from c in db.Customers
                //                where c.City == "London"
                //                select c;
                var customers = from c in db.Customers
                                where c.City == "London"
                                select new
                                {
                                    c.CustomerId,
                                    c.ContactName,
                                    c.CompanyName,
                                    c.City
                                };

                foreach (var cust in customers)
                {
                    Console.WriteLine($"{cust.CustomerId}" +
                        $" | {cust.CompanyName}" +
                        $" | {cust.ContactName}" +
                        $" | {cust.City}");
                }
            }

        }

        static void GetOrders(string customerId)
        {
            Console.WriteLine();
            Console.WriteLine("GetOrders()...");

            using (var db = new NWDbContext())
            {
                db.Database.Log = Console.Write;

                var customerOrders = db.Customers
                    //.Include("Orders")
                    .Include("Orders.Employee")
                    //.Include("Orders.OrderDetails")
                    .Include("Orders.OrderDetails.Product")
                    //.Include("Orders.Regions")        // Wont' work!
                    .Where(c => c.CustomerId == customerId);

                foreach (var cust in customerOrders)
                {
                    Console.WriteLine($"" +
                        $"{cust.CustomerId}"
                        );
                    foreach (var order in cust.Orders)
                    {
                        Console.WriteLine($"\t{order.OrderId}" +
                            $" | {order.OrderDate}" +
                            $" | {order.EmployeeId}" +
                            $" | {order.Employee.Firstname} {order.Employee.Lastname}"
                            );

                        //// Won't Work!!!
                        //foreach(var region in order.Regions)
                        //{
                        //    Console.WriteLine($"\t\t{region.RegionId}" +
                        //        $" | {region.RegionDescription}");
                        //}

                        foreach (var detail in order.OrderDetails)
                        {
                            Console.WriteLine($"\t\t{detail.ProductId}" +
                                $" | {detail.Product.ProductName}" +
                                $" | {detail.Quantity}" +
                                $" | {detail.UnitPrice}");
                        }
                    }
                }

                //// Eager Loading.
                //var orders = db.Orders
                //    .Include("Customer")
                //    .Include("Employee")
                //    .Include("OrderDetails")
                //    .Include("OrderDetails.Product")
                //    .Where(o => o.CustomerId == customerId);
                //foreach (var order in orders)
                //{
                //    Console.WriteLine($"{order.OrderId}" +
                //        $" | {order.OrderDate}" +
                //        $" | {order.CustomerId}" +
                //        $" | {order.Customer.ContactName}" +
                //        $" | {order.EmployeeId}" +
                //        $" | {order.Employee.Lastname}, {order.Employee.Firstname}"
                //        );

                //    foreach (var details in order.OrderDetails)
                //    {
                //        Console.WriteLine($"\t{details.ProductId}" +
                //            $" | {details.Product.ProductName}" +
                //            $" | {details.Quantity}" +
                //            $" | {details.UnitPrice}");
                //    }
                //}
            }
        }

        static void ExplicitLoading(string customerId)
        {
            Console.WriteLine();
            Console.WriteLine("GetOrders()...");

            using (var db = new NWDbContext())
            {
                var ordersTemp = db.Orders
                    .Where(o => o.CustomerId == customerId);
                //.ToList<Order>();

                //var custTemp= db.Customers
                //    .Where(c => c.CustomerId == customerId)
                //    .SingleOrDefault<Customer>();

                //var orders = ordersTemp.ToList();   // To demonstrate Lazy Loading.
                foreach (var order in ordersTemp)
                {
                    Console.WriteLine($"{order.OrderId}" +
                        $" | {order.OrderDate}"
                        //$" | {order.CustomerId}" +
                        //$" | {order.Customer.ContactName}" +
                        //$" | {order.EmployeeId}" +
                        //$" | {order.Employee.Lastname}, {order.Employee.Firstname}"
                        );

                    //db.Entry(order).Reference(o => o.Employee).Load();
                    //Console.WriteLine(
                    //    $"\t{order.EmployeeId}" +
                    //    $" | {order.Employee.Lastname}, {order.Employee.Firstname}"
                    //    );

                    //db.Entry(order).Collection(o => o.OrderDetails).Load();
                    //foreach (var details in order.OrderDetails)
                    //{
                    //    Console.WriteLine($"\t\t{details.ProductId}" +
                    //        //$" | {details.Product.ProductName}" +
                    //        $" | {details.Quantity}" +
                    //        $" | {details.UnitPrice}");
                    //}
                }

            }
        }

        static void CreateCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("CreateCustomer()...");

            using (var db = new NWDbContext())
            {
                var customer = new Customer
                {
                    CustomerId = "MRYJN",
                    CompanyName = "Some Company",
                    ContactName = "Mary Jane",
                    City = "NYC"
                };

                db.Customers.Add(customer);
                db.SaveChanges();
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
                    } catch(Exception ex)
                    {
                        txn.Rollback();
                        Console.WriteLine($"ERROR! {ex.ToString()}");
                    }
                }
            }
        }

        static void CreateRegion()
        {
            Console.WriteLine();
            Console.WriteLine("CreateRegion()...");

            using (var db = new NWDbContext())
            {
                var region = new Region
                {
                    RegionId = 98,
                    RegionDescription = "Region no. 98"
                };

                db.Regions.Add(region);
                db.SaveChanges();
            }
        }

        static void DeleteOrder()
        {
            Console.WriteLine();
            Console.WriteLine("DeleteOrder()...");

            using(var db = new NWDbContext())
            {
                var ordersToDelete = db.Orders
                    .Include(o => o.OrderDetails)         // Cascade Deletes.
                    .Where(o => o.OrderId > 11079)
                    .ToList();
                db.Orders.RemoveRange(ordersToDelete);
                db.SaveChanges();
            }
        }
    }
}
