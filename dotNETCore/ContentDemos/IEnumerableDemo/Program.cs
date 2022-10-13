namespace IEnumerableDemo
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Foreach for List<Customer>...");
            List<Customer> list = new List<Customer>()
            {
                new Customer { Name = "John Smith", City = "Reston", Id = 101 },
                new Customer { Name = "Mary Jane", City = "Dallas", Id = 102 },
                new Customer { Name = "Joe Quill", City = "Orlando", Id = 103 }
            };
            foreach(Customer customer in list)
            {
                Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, City: {customer.City}");
            }

            Console.WriteLine("MyCollection...");
            MyCollection myColl = new MyCollection();
            foreach(var item in myColl)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nMyIntList...");
            MyIntList myIntList = new MyIntList();
            foreach(var item in myIntList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nMyIntListGen...");
            MyIntListGen myIntListGen = new MyIntListGen();
            foreach (var item in myIntListGen)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nCustomerArray...");
            Customer[] customerArray = new Customer[]
            {
                new Customer { Name = "John Smith", City = "Reston", Id = 101 },
                new Customer { Name = "Mary Jane", City = "Dallas", Id = 102 },
                new Customer { Name = "Joe Quill", City = "Orlando", Id = 103 }
            };

            var customers = new CustomerList(customerArray);

            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {((Customer)customer).Id}, Name: {((Customer)customer).Name}, City: {((Customer)customer).City}");
            }

            var customerList = new CustomerList(customerArray);            
            foreach (var customer in customerList)
            {
                Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, City: {customer.City}");
            }

        }
    }
}
