using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSeed.Entities
{
    public class Standard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Associate> Associates { get; set; }
    }
}
