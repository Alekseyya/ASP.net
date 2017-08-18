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
    public class ModificationRepository : IModificationRepository
    {
        private readonly WebStoreContext _context;
        public ModificationRepository(WebStoreContext context)
        {
            _context = context;
        }
        public void Create(Modification item)
        {
            _context.Modifications.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Modification modification = _context.Modifications.FirstOrDefault(o => o.Id == id);
            var variants = _context.Variants.Where(o => o.Id == modification.Id);
            foreach (var variant in variants)
            {
                _context.Variants.Remove(variant);
            }
            _context.Modifications.Remove(modification);
            _context.SaveChanges();
        }

        public Modification GetItem(int id)
        {
            return _context.Modifications.Include("Model").FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Modification> GetList()
        {
            return _context.Modifications.Include("Model").ToList();
        }

        public void Update(Modification item)
        {
            var modification = _context.Modifications.FirstOrDefault(o => o.Id == item.Id);
            bool isModified = false;

            if (modification.ModelId != item.ModelId)
            {
                modification.ModelId = item.ModelId;
                isModified = true;
            }

            if (modification.Name != item.Name)
            {
                modification.Name = item.Name;
                isModified = true;
            }

            if (modification.TypeSort != item.TypeSort)
            {
                modification.TypeSort = item.TypeSort;
                isModified = true;
            }


            if (isModified)
            {
                _context.Entry(modification).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
