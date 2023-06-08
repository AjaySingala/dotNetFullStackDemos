using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFRelations.Entities
{
    //Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CustomerDB;Integrated Security=true;AttachDbFileName=C:\Data\CustomerDB.mdf"
    public class StudentDbContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Associate> Associates{ get; set; }
        public DbSet<Course> Courses{ get; set; }

    }
}
