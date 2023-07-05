using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Entities
{
    public class CustomOrder
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Name { get; set; }
    }
}
