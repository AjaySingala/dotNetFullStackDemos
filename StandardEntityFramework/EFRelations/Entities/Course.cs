using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelations.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Virtual to support lazy loading and nullable Foreign Key in SQL.
        public virtual ICollection<Associate> Associates { get; set; }

        public Course()
        {
            this.Associates = new HashSet<Associate>();
        }
    }
}
