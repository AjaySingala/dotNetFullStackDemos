using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoCore.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }

        public Customer Customer { get; set; }      // Reference Navigation Property.
        public Employee Employee { get; set; }      // Reference Navigation Property
        public virtual List<OrderDetail> OrderDetails { get; set; }
        
        //// Won't Work!!
        //public List<Region> Regions { get; set; }
    }
}
