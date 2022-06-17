using RepoUnitOfWorkDP.Entities;
using RepoUnitOfWorkDP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitOfWorkDP.UnitOfWork
{
    public class OrderUnitOfWork
    {
        private readonly CustomerRepository _customerRepository;
        private readonly OrderRepository _orderRepository;
        private readonly ECommerceContext _context;

        public OrderUnitOfWork(ECommerceContext context)
        {
            _context = context;
            _customerRepository = new CustomerRepository(context);
            _orderRepository = new OrderRepository(context);
        }
        public OrderUnitOfWork(ECommerceContext context, CustomerRepository customer, OrderRepository orderRepository)
        {
            _context = context;
            _customerRepository = customer;
            _orderRepository = orderRepository;
        }
        public OrderUnitOfWork(ECommerceContext context, CustomerRepository customer)
        {
            _context = context;
            _customerRepository = customer;
            _orderRepository = new OrderRepository(context);
        }
        public OrderUnitOfWork(ECommerceContext context, OrderRepository orderRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
            _customerRepository = new CustomerRepository(context);
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
