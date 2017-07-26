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
        private static WebStoreContext _context;
        static WebStoreContext()
        {
            _context = new WebStoreContext();
        }

        public static WebStoreContext Instance
        {
            get
            {
                return _context;
            }
        }
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
