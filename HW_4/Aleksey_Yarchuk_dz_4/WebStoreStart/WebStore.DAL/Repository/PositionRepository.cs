using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.DAL.Interface;
using WebStore.Domain.Entities;


namespace WebStore.DAL.Repository
{
    public class PositionRepository : IRepository<Position>
    {
        WebStoreContext db;
        public PositionRepository()
        {
            this.db = new WebStoreContext();
        }
        public void Create(Position item)
        {
            db.Positions.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Position pos = db.Positions.FirstOrDefault(posi => posi.Id == id);
            if (pos != null)
            {
                db.Positions.Remove(pos);
                db.SaveChanges();
            }
        }

        public Position GetItem(int id)
        {
            var pos = db.Positions.FirstOrDefault(posi => posi.Id == id);
            if (pos != null)
            {
                return pos;
            }
            return null;
        }

        public IList<Position> GetList()
        {
            return db.Positions.ToList();
        }

        public void Update(Position pos)
        {
            var position = db.Positions.FirstOrDefault(posi => posi.Id == pos.Id);
            bool isModified = false;

            if (position.Name != pos.Name)
            {
                position.Name = pos.Name;
                isModified = true;
            }
           
            if (isModified)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
