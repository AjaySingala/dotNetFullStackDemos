using RepoUnitOfWorkDP.BL;
using RepoUnitOfWorkDP.Entities;
using RepoUnitOfWorkDP.Repositories;

class Program
{
    static void Main()
    {
        //// Create data.
        //CreateData();

        //// With Repo.
        //RepoDemo(1);

        //// Unit of work.
        //UnitOfWork();
    }

    static void DisplayCustomer(Customer customer)
    {
        Console.WriteLine($"Customer Id: {customer.Id} : {customer.Firstname} {customer.Lastname} : {customer.City}");
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine($"Order Id: {order.Id} : {order.OrderDate}");
        DisplayCustomer(order.Customer);
    }

    static void UnitOfWork()
    {
        Console.WriteLine("\nUsing Unit of Work Design Pattern...");

        UnitOfWorkBL uowBL = new UnitOfWorkBL();

        var customer = new Customer
        {
            Firstname = "Bruce",
            Lastname = "Wayne",
            City = "Gotham"
        };

        var order = new Order
        {
            CustomerId = customer.Id,
            OrderDate = DateTime.Now,
            Customer = customer
        };

        // Check out Customer Id assignment to Order.
        uowBL.CreateCustomer(customer);
        uowBL.CreateOrder(order);

        RepoDemo(order.Id);

        Console.WriteLine("Done!");
    }

    static void RepoDemo(int id)
    {
        Console.WriteLine("\nRepository Design Pattern Demo...");

        OrderBL orderBL = new OrderBL();
        var order = orderBL.Get(id);
        DisplayOrder(order);

        CustomerBL custBL = new CustomerBL();
        var customer = custBL.Get(order.CustomerId);
        DisplayCustomer(customer);

        Console.WriteLine("Done!");
    }

    static void CreateData()
    {
        Console.WriteLine("\nCreating the initial data without any Repository...");

        using (var context = new ECommerceContext())
        {
            var customer = new Customer
            {
                Firstname = "John",
                Lastname = "Smith",
                City = "Reston"
            };

            var order = new Order
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                Customer = customer
            };
            context.Customers.Add(customer);
            context.Orders.Add(order);
            context.SaveChanges();

            Console.WriteLine("Done!");
        }
    }
}

