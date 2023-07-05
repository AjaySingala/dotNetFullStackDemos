using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Entities
{
    public class NWDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>()
                .HasKey(t => new { t.OrderId, t.ProductId });

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //var eTypes = modelBuilder.Model.GetEntityTypes();
            //foreach (var type in eTypes)
            //{
            //    var foreignKeys = type.GetForeignKeys();
            //    foreach (var foreignKey in foreignKeys)
            //    {
            //        foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            //    }
            //}

            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.OrderDetails)
            //    .WithRequired(od => od.Order)
            //    .WillCascadeOnDelete(false);
        }
    }
}
