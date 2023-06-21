using System.Data.Entity;

namespace EnumDbDemo
{
    public class EnumDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}
