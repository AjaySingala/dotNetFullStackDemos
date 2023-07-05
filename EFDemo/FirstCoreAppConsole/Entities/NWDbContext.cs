//install-package Microsoft.EntityFrameworkCore
//install-package Microsoft.EntityFrameworkCore.SqlServer
//install-package Microsoft.Extensions.Configuration
//install-package Microsoft.Extensions.Configuration.Json
//install-package Microsoft.Extensions.Hosting


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FirstCoreAppConsole.Entities
{
//public class NWDbContext : DbContext
//{
//    private readonly IConfiguration _iConfiguration;
//    private readonly string _connectionString;

//    public DbSet<Customer> Customers { get; set; }
//    //public DbSet<Product> Products { get; set; }
//    //public DbSet<Order> Orders { get; set; }
//    //public DbSet<OrderDetail> OrderDetails { get; set; }
//    //public DbSet<Employee> Employees { get; set; }
//    //public DbSet<Region> Regions { get; set; }

//    public NWDbContext()
//    {
//        // Build a config object, using env vars and JSON providers.
//        var builder = new ConfigurationBuilder()
//            .AddJsonFile("appSettings.json");
//            //.AddEnvironmentVariables();
            
//        _iConfiguration = builder.Build();
//        _connectionString = _iConfiguration.GetConnectionString("northwind");
//    }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer(_connectionString);
//    }

//    //protected override void OnModelCreating(ModelBuilder modelBuilder)
//    //{
//    //    //base.OnModelCreating(modelBuilder);
//    //    modelBuilder.Entity<OrderDetail>()
//    //        .HasKey(t => new { t.OrderId, t.ProductId });

//    //    modelBuilder.Entity<EFDemoCore.Entities.TempEntities.Customer>()
//    //        .HasMany(c => c.Addresses)
//    //        .WithOne(a => a.Customer)
//    //        .OnDelete(DeleteBehavior.ClientSetNull);
//    //}
//    }
}
