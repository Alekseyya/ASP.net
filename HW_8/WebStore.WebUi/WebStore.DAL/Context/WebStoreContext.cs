using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Context
{
   public class WebStoreContext :DbContext
    {        
        public WebStoreContext()
            : base("DbContext")
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Modification> Modifications { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Variant> Variants { get; set; }
        



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailsConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());

            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new MarkConfiguration());
            modelBuilder.Configurations.Add(new ModelConfiguration());
            modelBuilder.Configurations.Add(new ModificationConfiguration());
            modelBuilder.Configurations.Add(new PhotoConfiguration());
            modelBuilder.Configurations.Add(new VariantConfiguration());
        }

        public class DatabaseInitializer
        : CreateDatabaseIfNotExists<WebStoreContext>
        {
            public override void InitializeDatabase(WebStoreContext context)
            {

            }
        }
    }
}
