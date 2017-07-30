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
            context.Users.AddOrUpdate(u => u.Id,
                new User { Id = 1, Name= "Admin", Password="12345", IsDeleted = false, GroupId =1},
                new User { Id = 2, Name = "Manager", Password = "12345", IsDeleted = false, GroupId = 2 }
                );
            context.Groups.AddOrUpdate(u => u.Id,
                new Group { Id = 1, Name="Administrator"},
                new Group { Id = 2, Name = "Manager" }
                );
            context.Products.AddOrUpdate(u => u.Id,
                new Product { Id=1, Name="Кефир", Descriptions="Кефир свежий", Price=12.5m , CategoryId=1, Count=4, IsDeleted= false},
                new Product { Id=2, Name="Молоко", Descriptions="Молоко свежее", Price=5.5m, CategoryId=1, Count=4, IsDeleted=false},
                new Product { Id=3, Name="Гречка", Descriptions="Перламутр", Price=10.3m, CategoryId=2, Count=10, IsDeleted=false},
                new Product { Id=4, Name="Барилла", Descriptions= "Итальянские макароны", Price=13.7m, CategoryId=3, Count=10, IsDeleted=false}
                );

            context.Categories.AddOrUpdate(u => u.Id,
                new Category { Id = 1, Name = "Молочная продукция" },
                new Category { Id = 2, Name = "Крупа" },
                new Category { Id = 3, Name = "Макароны" }
            );
            context.SaveChanges();
        }
    }
}
