using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSeed.Entities
{
    public class Associate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StandardId { get; set; }
        public Standard Standard { get; set; }
    }
}
