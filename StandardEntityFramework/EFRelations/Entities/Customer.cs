using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelations.Entities
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        // Collection Navigation Property.
        public IList<Order> Orders { get; set; }
    }
}
