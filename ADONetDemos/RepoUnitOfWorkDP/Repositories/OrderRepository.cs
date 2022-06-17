using Microsoft.EntityFrameworkCore;
using RepoUnitOfWorkDP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitOfWorkDP.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ECommerceContext _context;
        public OrderRepository(ECommerceContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            //_context.SaveChanges();
        }

        public Order Get(int id)
        {
            var order = _context.Orders.Where(o => o.Id == id)
                .Include(o => o.Customer)
                .FirstOrDefault<Order>();
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
