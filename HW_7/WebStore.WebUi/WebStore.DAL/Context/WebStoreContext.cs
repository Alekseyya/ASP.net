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

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
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
