using BankingApp.Entities;

namespace BankingApp.DAL
{
    public class CustomerDbService
    {
        static List<Customer> _customers = new List<Customer>();

        public Customer Create(Customer customer)
        {
            // Generate random Customer Number (id).
            var rnd = new Random();
            customer.Id = rnd.Next(10000, 20000);

            // Add account to list of accounts.
            _customers.Add(customer);

            return customer;
        }

        public List<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(int id)
        {
            return _customers.Find(c => c.Id == id)!;
        }


        public Customer Update(Customer customer)
        {
            var indexOf = _customers.IndexOf(customer);
            _customers[indexOf] = customer;

            return customer;
        }
    }
}