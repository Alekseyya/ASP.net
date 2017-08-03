using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Repositories
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly WebStoreContext _context;
        public AuthenticationRepository(WebStoreContext context)
        {
            _context = context;
        }

        public bool RegisterUser(User user)
        {
            bool isSaved = false;
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
            }
            return isSaved;
        }
        public bool RegisterUser(string userName, string userPassword, int groupId)
        {
            bool isSaved = false;
            try
            {
                _context.Users.Add(new User { Name = userName, Password = userPassword, GroupId = groupId, IsDeleted = false });
                _context.SaveChanges();
                isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
            }
            return isSaved;
        }
        public bool RemoveUser(User userToRemove)
        {
            bool isRemoved = false;
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == userToRemove.Id);
                if (user == null)
                    return false;
                user.IsDeleted = true;
                _context.SaveChanges();
                isRemoved = true;
            }
            catch (Exception ex)
            {
                isRemoved = false;
            }
            return isRemoved;
        }
        public bool RemoveUser(int id)
        {
            bool isRemoved = false;
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                    return false;
                user.IsDeleted = true;
                _context.SaveChanges();
                isRemoved = true;
            }
            catch (Exception ex)
            {
                isRemoved = false;
            }

            return isRemoved;
        }
    }
}
