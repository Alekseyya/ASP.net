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
    public class RoleRepository : IRepository<Role>
    {
        WebStoreContext db;
        public RoleRepository()
        {
            this.db = new WebStoreContext();
        }
        public void Create(Role item)
        {
            db.Roles.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Role rol = db.Roles.FirstOrDefault(r => r.Id == id);
            if (rol != null)
            {
                db.Roles.Remove(rol);
                db.SaveChanges();
            }
        }

        public Role GetItem(int id)
        {
            var rol = db.Roles.FirstOrDefault(r => r.Id == id);
            if (rol != null)
            {
                return rol;
            }
            return null;
        }

        public IList<Role> GetList()
        {
            return db.Roles.ToList();
        }

        public void Update(Role rol)
        {
            var roles = db.Roles.FirstOrDefault(r => r.Id == rol.Id);
            bool isModified = false;

            if (roles.Name != rol.Name)
            {
                roles.Name = rol.Name;
                isModified = true;
            }

            if (isModified)
            {
                db.Entry(roles).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
