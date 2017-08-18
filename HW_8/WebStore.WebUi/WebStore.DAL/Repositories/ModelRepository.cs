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
    public class ModelRepository : IModelRepository
    {
        private readonly WebStoreContext _context;
        public ModelRepository(WebStoreContext context)
        {
            _context = context;
        }
        public void Create(Model item)
        {
            _context.Models.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Model model = _context.Models.FirstOrDefault(o => o.Id == id);
            var modifications = _context.Modifications.Where(o => o.ModelId == model.Id);
            foreach (var modification in modifications)
            {
                _context.Modifications.Remove(modification);
            }
            _context.Models.Remove(model);
            _context.SaveChanges();
        }

        public Model GetItem(int id)
        {
            return _context.Models.Include("Mark").Include("Photo").FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Model> GetList()
        {
            return _context.Models.Include("Mark").Include("Photo").ToList();
        }

        public void Update(Model item)
        {
            var model = _context.Models.FirstOrDefault(o => o.Id == item.Id);
            bool isModified = false;

            if (model.MarkId != item.MarkId)
            {
                model.MarkId = item.MarkId;
                isModified = true;
            }

            if (model.Name != item.Name)
            {
                model.Name = item.Name;
                isModified = true;
            }

            if (model.Years_Body != item.Years_Body)
            {
                model.Years_Body = item.Years_Body;
                isModified = true;
            }

            if (model.Start != item.Start)
            {
                model.Start = item.Start;
                isModified = true;
            }

            if (model.End != item.End)
            {
                model.End = item.End;
                isModified = true;
            }

            if (model.TecDoc != item.TecDoc)
            {
                model.TecDoc = item.TecDoc;
                isModified = true;
            }

            if (model.PhotoId != item.PhotoId)
            {
                model.PhotoId = item.PhotoId;
                isModified = true;
            }

            if (model.Main != item.Main)
            {
                model.Main = item.Main;
                isModified = true;
            }

            if (model.Market != item.Market)
            {
                model.Market = item.Market;
                isModified = true;
            }

            if (model.Type != item.Type)
            {
                model.Type = item.Type;
                isModified = true;
            }

            if (isModified)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
