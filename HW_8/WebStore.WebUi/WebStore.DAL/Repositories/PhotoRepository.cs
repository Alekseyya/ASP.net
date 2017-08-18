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
    public class PhotoRepository : IPhotoRepository
    {

        private readonly WebStoreContext _context;
        public PhotoRepository(WebStoreContext context)
        {
            _context = context;
        }

        public void Create(Photo item)
        {
            _context.Photos.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Photo photo = _context.Photos.FirstOrDefault(o => o.Id == id);
            //удаление всех связей данного фото.
            
            var models = _context.Models.Where(o => o.PhotoId == photo.Id);
            foreach (var model in models)
            {
                model.PhotoId = null;
                //обновляем запись модель(автомобиля), убирая картинку
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }
            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

        public Photo GetItem(int id)
        {
            return _context.Photos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Photo> GetList()
        {
            return _context.Photos.ToList();
        }

        public void Update(Photo item)
        {
            var photo = _context.Photos.FirstOrDefault(o => o.Id == item.Id);
            bool isModified = false;

            if (photo.Name != item.Name)
            {
                photo.Name = item.Name;
                isModified = true;
            }
            
            if (isModified)
            {
                _context.Entry(photo).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
