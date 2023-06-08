using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFDBFirst.Entities
{
    //Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CustomerDB;Integrated Security=true;AttachDbFileName=C:\Data\CustomerDB.mdf"
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
