﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTxns.Entities
{
    public class Associate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Virtual to support lazy loading and nullable Foreign Key in SQL.
        public virtual ICollection<Course> Courses { get; set; }
        public Standard Standard { get; set; }

        public Associate()
        {
            this.Courses = new HashSet<Course>();
        }
    }
}
