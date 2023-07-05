using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoCore.Entities.TempEntities
{
    public class Address
    {
        public int AddressId { get; set; }
        public virtual int? CustomerId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }

        public virtual Customer? Customer { get; set; }

    }
}
