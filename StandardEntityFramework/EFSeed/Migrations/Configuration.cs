namespace EFSeed.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFSeed.Entities.EFSeedDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFSeed.Entities.EFSeedDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Standards.AddOrUpdate(x => x.Id,
                new Entities.Standard { Id = 801, Name = "Level 1" },
                new Entities.Standard { Id = 802, Name = "Level 2" },
                new Entities.Standard { Id = 803, Name = "Level 3" }
            );

            context.Associates.AddOrUpdate(x => x.Id,
                new Entities.Associate { Id = 901, Name = "Henry", StandardId = 801 },
                new Entities.Associate { Id = 902, Name = "Lucy", StandardId = 802 },
                new Entities.Associate { Id = 903, Name = "Jason", StandardId = 801 }
            );
        }
    }
}
