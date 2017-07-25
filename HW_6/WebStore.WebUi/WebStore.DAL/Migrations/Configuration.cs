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
