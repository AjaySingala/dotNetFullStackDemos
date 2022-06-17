using RepoUnitOfWorkDP.Entities;
using RepoUnitOfWorkDP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitOfWorkDP.BL
{
    public class CustomerBL
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerBL()
        {
            _customerRepo = new CustomerRepository(new ECommerceContext());
        }

        public CustomerBL(CustomerRepository repo)
        {
            _customerRepo = repo;
        }

        public Customer Get(int id)
        {
            var customer = _customerRepo.Get(id);
            return customer;
        }
    }
}
