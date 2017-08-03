using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Repositories.Base;

using WebStore.Services.Services.Base;

namespace WebStore.Services.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckUser(string userName, string userPassword)
        {
            var bytes = Encoding.UTF8.GetBytes(userPassword);
            var passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            var user = _unitOfWork.UserRepository.GetItemByName(userName);
            if (user == null)
                return false;
            return user.Password == passwordBase64;
        }

        public bool RegisterUser(string userName, string userPassword)
        {
            var bytes = Encoding.UTF8.GetBytes(userPassword);
            var passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            var user = _unitOfWork.UserRepository.GetItemByName(userName);
            if (user != null)
                return false;
            return _unitOfWork.AuthenticationRepository.RegisterUser(new Domain.Entities.User
            {
                GroupId = 2,
                IsDeleted = false,
                Name = userName,
                Password = passwordBase64
            });
        }
    }
}
