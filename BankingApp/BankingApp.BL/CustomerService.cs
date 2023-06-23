using BankingApp.DAL;
using BankingApp.Entities;

namespace BankingApp.BL
{
    public class CustomerService
    {
        public Customer Create(Customer customer)
        {
            CustomerDbService svc = new CustomerDbService();
            svc.Create(customer);

            return customer;
        }

        public Customer Update(Customer customer)
        {
            CustomerDbService svc = new CustomerDbService();
            svc.Update(customer);

            return customer;
        }

        public List<Customer> Get()
        {
            CustomerDbService svc = new CustomerDbService();
            var customers = svc.Get();

            return customers;
        }

        public Customer Get(int id)
        {
            CustomerDbService svc = new CustomerDbService();
            var customer = svc.Get(id);

            return customer;
        }
    }
}
