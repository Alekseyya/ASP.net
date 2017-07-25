using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;

namespace WebStore.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private WebStoreContext db = new WebStoreContext();
        private CategoryRepository categoryRepository;
        private ProductPepository productRepository;

        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public ProductPepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductPepository(db);
                return productRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
