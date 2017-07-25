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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
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
