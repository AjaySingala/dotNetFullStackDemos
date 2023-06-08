using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelations.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        // Reference Navigation Property.
        public Grade Grade { get; set; }
    }
}
