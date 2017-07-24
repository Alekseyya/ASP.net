namespace WebStore.DAL.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebStore.DAL.Context.WebStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebStore.DAL.Context.WebStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Products.AddOrUpdate(u => u.Id,
                new Product
                {
                    Id=1,
                    Name = "��������",
                    Count = 2
                },
                new Product
                {
                    Id = 2,
                    Name = "������",
                    Count = 3
                },
                 new Product
                 {
                     Id = 3,
                     Name = "���",
                     Count = 5
                 }
                );
            context.SaveChanges();
        }
    }
}
