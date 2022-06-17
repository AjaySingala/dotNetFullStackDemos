using RepoUnitOfWorkDP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitOfWorkDP.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ECommerceContext _context;
        public CustomerRepository(ECommerceContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            //_context.SaveChanges();
        }

        public Customer Get(int id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
