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
    public class UserRepository : IRepository<User>
    {
        WebStoreContext db;
        public UserRepository()
        {
            this.db = new WebStoreContext();
        }
        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = db.Users.FirstOrDefault(us => us.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public User GetItem(int id)
        {
            var user = db.Users.FirstOrDefault(us => us.Id == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public IList<User> GetList()
        {
            return db.Users.ToList();
        }

        public void Update(User us)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == us.Id);
            bool isModified = false;

            if (user.Login != us.Login)
            {
                user.Login = us.Login;
                isModified = true;
            }

            if (user.Password != us.Password)
            {
                user.Password = us.Password;
                isModified = true;
            }


            if (user.RoleId != us.RoleId)
            {
                var userTmp = db.Roles.FirstOrDefault(id => id.Id == us.RoleId);
                if(userTmp!= null)
                {
                    user.RoleId = us.RoleId;
                    isModified = true;
                }
            }

            if (isModified)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
