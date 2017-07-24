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
        public ProductPepository()
        {
            this.db = new WebStoreContext();
        }
        public void Create(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Product prod = db.Products.FirstOrDefault(o => o.Id == id);
            db.Products.Remove(prod);
            db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Product GetItem(int id)
        {
            return db.Products.FirstOrDefault(o => o.Id == id);
        }

        public IList<Product> GetList()
        {
            var tt = db.Products.ToList();
            return db.Products.ToList();
        }

        public void Update(Product item)
        {
            var prod = db.Products.FirstOrDefault(o => o.Id == item.Id);
            bool isModified = false;

            if (prod.Name != item.Name)
            {
                prod.Name = item.Name;
                isModified = true;
            }

            if (prod.Count != item.Count)
            {
                prod.Count = item.Count;
                isModified = true;
            }

            if (isModified)
            {
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
