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
    public class MarkRepository : IMarkRepository
    {
        private readonly WebStoreContext _context;
        public MarkRepository(WebStoreContext context)
        {
            _context = context;
        }

        public void Create(Mark item)
        {
            _context.Marks.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Mark mark = _context.Marks.FirstOrDefault(o => o.Id == id);
            var models = _context.Models.Where(o => o.MarkId == mark.Id);
            //удаление всех связанные моделей с маркой
            foreach (var model in models)
            {
                _context.Models.Remove(model);
            }
            _context.Marks.Remove(mark);
            _context.SaveChanges();
        }

        public Mark GetItem(int id)
        {
            //найти марку по id
            return _context.Marks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Mark> GetList()
        {
            //список всех марок
            return _context.Marks.ToList();
        }

        public void Update(Mark item)
        {
            var mark = _context.Marks.FirstOrDefault(o => o.Id == item.Id);
            bool isModified = false;            

            if (mark.Name != item.Name)
            {
                mark.Name = item.Name;
                isModified = true;
            }

            if (mark.Main != item.Main)
            {
                mark.Main = item.Main;
                isModified = true;
            }

            if (isModified)
            {
                _context.Entry(mark).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
