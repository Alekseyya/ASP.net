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
    public class UserRepository: IUserRepository
    {
        private readonly WebStoreContext _context;

        public UserRepository(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetList()
        {
            return _context.Users.Include("Group").ToArray();
        }
        
        public User GetItem(int id)
        {
            return _context.Users.Include("Group").FirstOrDefault(x => x.Id == id);
        }

        public User GetItemByName(string name)
        {
            return _context.Users.Include("Group").FirstOrDefault(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        
        public void Create(User user)
        {
            _context.Users.Add(user);             
        }
        public void Update(User user)
        {
            var userT = _context.Users.FirstOrDefault(o => o.Id == user.Id);
            bool isModified = false;

            if (userT.Name != user.Name)
            {
                userT.Name = user.Name;
                isModified = true;
            }

            if (userT.Password != user.Password)
            {
                userT.Password = user.Password;
                isModified = true;
            }
            if (userT.GroupId != user.GroupId)
            {
                userT.GroupId = user.GroupId;
                isModified = true;
            }
            if (userT.IsDeleted != user.IsDeleted)
            {
                userT.IsDeleted = user.IsDeleted;
                isModified = true;
            }
            if (userT.IsDeleted != user.IsDeleted)
            {
                userT.IsDeleted = user.IsDeleted;
                isModified = true;
            }
            

            if (isModified)
            {
                _context.Entry(userT).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(o => o.Id == id);
            _context.Users.Remove(user);
        }
        public bool RestoreUser(int id)
        {
            //try
            //{
            //    var user = GetItem(id);
            //    if (user == null)
            //        return false;
            //    user.IsDeleted = false;
            //    _context.SaveChanges();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}

            return false;
        }
    }
}
