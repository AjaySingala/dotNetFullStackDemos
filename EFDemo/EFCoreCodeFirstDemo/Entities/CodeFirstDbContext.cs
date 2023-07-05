//install-package Microsoft.EntityFrameworkCore
//install-package Microsoft.EntityFrameworkCore.SqlServer
//install-package Microsoft.EntityFrameworkCore.Tools

//Add-Migration <migrtion_name>
//Update-Database

using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstDemo.Entities
{
    public class CodeFirstDbContext : DbContext
    {
        string _connectionString = @"Server=.\SQLEXPRESS;Initial Catalog=CodeFirstDB;Integrated Security=true;TrustServerCertificate=True;";

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            // Seed data.
            modelBuilder.Entity<Customer>()
                .HasData(new Customer { Id = 1, Firstname = "John", Lastname = "Smith" });
            modelBuilder.Entity<Address>()
                .HasData(new Address
                {
                    Id = 1,
                    AddressLine1 = "123 Abbey Road",
                    AddressLine2 = "2nd Floor",
                    City = "London",
                    CustomerId = 1
                });
        }
    }
}
