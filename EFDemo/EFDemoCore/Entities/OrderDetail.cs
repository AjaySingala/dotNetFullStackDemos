using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoCore.Entities
{
    [Table("Order Details")]
    public class OrderDetail
    {
        // Composite Key defined in DbContext's OnModelCreating() method.
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
