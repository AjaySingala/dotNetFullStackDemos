using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFTxns.Entities
{
    //Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CustomerDB;Integrated Security=true;AttachDbFileName=C:\Data\CustomerDB.mdf"
    public class EFTxnsDbContext : DbContext
    {
        public DbSet<Associate> Associates{ get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Standard> Standards { get; set; }

    }
}
