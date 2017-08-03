using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Repositories.Base
{
    public interface IAuthenticationRepository
    {
        bool RegisterUser(User user);

        bool RegisterUser(string userName, string userPassword, int groupId);

        bool RemoveUser(User userToRemove);

        bool RemoveUser(int id);
    }
}
