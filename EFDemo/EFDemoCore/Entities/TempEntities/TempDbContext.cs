using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoCore.Entities.TempEntities
{
    public class TempDbContext : DbContext
    {
        private readonly IConfiguration _iConfiguration;
        private readonly string _connectionString;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public TempDbContext()
        {
            // Build a config object, using env vars and JSON providers.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json");
            //.AddEnvironmentVariables();

            _iConfiguration = builder.Build();
            _connectionString = _iConfiguration.GetConnectionString("temp");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(o => o.Addresses)
                .WithOne(od => od.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
