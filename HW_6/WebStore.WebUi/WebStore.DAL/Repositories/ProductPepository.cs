using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Repositories
{
    public class ProductPepository : IRepository<Product>
    {
        WebStoreContext db;
        public ProductPepository(WebStoreContext context)
        {
            this.db = context;
        }
        public void Create(Product item)
        {
            db.Products.Add(item);            
        }

        public void Delete(int id)
        {
            Product prod = db.Products.FirstOrDefault(o => o.Id == id);
            db.Products.Remove(prod);            
        }

        
        public Product GetItem(int id)
        {
            return db.Products.FirstOrDefault(o => o.Id == id);
        }

        public IList<Product> GetList()
        {            
            return db.Products.ToList();
        }

        public void Update(Product prod)
        {
            var product = db.Products.FirstOrDefault(o => o.Id == prod.Id);
            bool isModified = false;

            if (product.Name != prod.Name)
            {
                product.Name = prod.Name;
                isModified = true;
            }

            if (product.Descriptions != prod.Descriptions)
            {
                product.Descriptions = prod.Descriptions;
                isModified = true;
            }
            if (product.Price != prod.Price)
            {
                product.Price = prod.Price;
                isModified = true;
            }
            if (product.CategoryId != prod.CategoryId)
            {
                product.CategoryId = prod.CategoryId;
                isModified = true;
            }
            if (product.IsDeleted != prod.IsDeleted)
            {
                product.IsDeleted = prod.IsDeleted;
                isModified = true;
            }
            if (product.Count != prod.Count)
            {
                product.Count = prod.Count;
                isModified = true;
            }

            if (isModified)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
