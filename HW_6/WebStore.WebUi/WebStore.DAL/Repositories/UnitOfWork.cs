using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.DAL.Repositories;
using WebStore.DAL.Repositories.Base;

namespace WebStore.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private WebStoreContext db;
        private CategoryRepository categoryRepository;
        private ProductPepository productRepository;

        public UnitOfWork()
        {
            db = WebStoreContext.Instance;
            ProductRepository = new ProductPepository(db);
            CategoryRepository = new CategoryRepository(db);
        }

        public UnitOfWork(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }

        //public CategoryRepository Categories
        //{
        //    get
        //    {
        //        if (categoryRepository == null)
        //            categoryRepository = new CategoryRepository(db);
        //        return categoryRepository;
        //    }
        //}

        //public ProductPepository Products
        //{
        //    get
        //    {
        //        if (productRepository == null)
        //            productRepository = new ProductPepository(db);
        //        return productRepository;
        //    }
        //}

        public IProductRepository ProductRepository{get; set;}

        public ICategoryRepository CategoryRepository { get; set; }

        public void Save()
        {
            db.SaveChanges();
        }
        
    }
}
