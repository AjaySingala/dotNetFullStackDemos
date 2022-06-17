using RepoUnitOfWorkDP.Entities;
using RepoUnitOfWorkDP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitOfWorkDP.BL
{
    public class OrderBL
    {
        private readonly OrderRepository _orderRepo;

        public OrderBL()
        {
            _orderRepo = new OrderRepository(new ECommerceContext());
        }

        public OrderBL(OrderRepository repo)
        {
            _orderRepo = repo;
        }

        public Order Get(int id)
        {
            var Order = _orderRepo.Get(id);
            return Order;
        }
    }
}
