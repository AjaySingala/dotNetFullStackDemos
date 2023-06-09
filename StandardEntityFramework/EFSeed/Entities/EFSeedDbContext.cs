using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFSeed.Entities
{
    public class EFSeedDbContext : DbContext
    {
        public EFSeedDbContext()
        {
            //Database.SetInitializer<EFSeedDbContext>(new CreateDatabaseIfNotExists<EFSeedDbContext>());
            //Database.SetInitializer<EFSeedDbContext>(new DropCreateDatabaseAlways<EFSeedDbContext>());
        }

        public DbSet<Associate> Associates{ get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}
