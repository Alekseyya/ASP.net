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
    public class CategoryRepository : IRepository<Category>
    {
        private WebStoreContext db;
        public CategoryRepository(WebStoreContext context)
        {
            this.db = context;
        }
        public void Create(Category category)
        {
            db.Categories.Add(category);
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }

        public Category GetItem(int id)
        {
            return db.Categories.FirstOrDefault(o => o.Id == id);
        }

        public IList<Category> GetList()
        {
            return db.Categories.ToList();
        }

        public void Update(Category categ)
        {
            var category = db.Categories.FirstOrDefault(o => o.Id == categ.Id);
            bool isModified = false;

            if (category.Name != categ.Name)
            {
                category.Name = categ.Name;
                isModified = true;
            }
              
            if (isModified)
            {
                db.Entry(category).State = EntityState.Modified;               
            }
        }
    }
}
