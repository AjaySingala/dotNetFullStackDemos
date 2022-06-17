using RepoUnitOfWorkDP.Entities;
using RepoUnitOfWorkDP.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitOfWorkDP.BL
{
    public class UnitOfWorkBL
    {
        private readonly OrderUnitOfWork _orderUnitOfWork;
        public UnitOfWorkBL()
        {
            _orderUnitOfWork = new OrderUnitOfWork(new ECommerceContext());
        }

        public void CreateCustomer(Customer customer)
        {
            _orderUnitOfWork.CreateCustomer(customer);
        }

        public void CreateOrder(Order order)
        {
            _orderUnitOfWork.CreateOrder(order);
            _orderUnitOfWork.Save();
        }
    }
}
