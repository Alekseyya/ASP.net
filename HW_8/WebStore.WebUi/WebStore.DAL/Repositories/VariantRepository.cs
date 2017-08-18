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
    public class VariantRepository : IVariantRepository
    {
        private readonly WebStoreContext _context;
        public VariantRepository(WebStoreContext context)
        {
            _context = context;
        }

        public void Create(Variant item)
        {
            _context.Variants.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Variant variant = _context.Variants.FirstOrDefault(o => o.Id == id);
            var items = _context.Items.Where(o => o.Id == variant.ItemId);
            foreach (var item in items)
            {
                _context.Items.Remove(item);
            }
            _context.Variants.Remove(variant);
            _context.SaveChanges();
        }

        public Variant GetItem(int id)
        {
            return _context.Variants.Include("Modification").Include("Item").FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Variant> GetList()
        {
            return _context.Variants.Include("Modification").Include("Item").ToList();
        }

        public void Update(Variant item)
        {
            var variant = _context.Variants.FirstOrDefault(o => o.Id == item.Id);
            bool isModified = false;

            if (variant.ModificationId != item.ModificationId)
            {
                variant.ModificationId = item.ModificationId;
                isModified = true;
            }

            if (variant.ItemId != item.ItemId)
            {
                variant.ItemId = item.ItemId;
                isModified = true;
            }

            if (variant.New != item.New)
            {
                variant.New = item.New;
                isModified = true;
            }

            if (isModified)
            {
                _context.Entry(variant).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
