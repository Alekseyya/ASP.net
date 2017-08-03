using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.DataContracts.Service;
using WebStore.Services.Services.Base;

namespace WebStore.Hosting
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "AuthenticationService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы AuthenticationService.svc или AuthenticationService.svc.cs в обозревателе решений и начните отладку.
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationService _service;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _service = new Services.Services.AuthenticationService(unitOfWork);
        }

        public bool CheckUser(string userName, string userPassword)
        {
            return _service.CheckUser(userName, userPassword);
        }

        public void DeleteGroup(int id)
        {
            _service.DeleteGroup(id);
        }

        public GroupDataContract GetGroupById(int id)
        {
            return _service.GetGroupById(id);
        }

        public IEnumerable<GroupDataContract> GetGroups()
        {
            return _service.GetGroups();
        }

        public bool RegisterUser(string userName, string userPassword)
        {
            return _service.RegisterUser(userName, userPassword);
        }

        public void UpdateGroup(GroupDataContract group)
        {
            _service.UpdateGroup(group);
        }

        public bool UserInGroup(string userName, string groupName)
        {
            return _service.UserInGroup(userName, groupName);
        }
        public bool AddUser(UserDataContract user)
        {
            return _service.AddUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _service.DeleteUser(id);
        }

        public bool EditUser(UserDataContract user)
        {
            return _service.EditUser(user);
        }
        public UserDataContract GetUser(string name)
        {
            return _service.GetUser(name);
        }

        public UserDataContract GetUser(int id)
        {
            return _service.GetUser(id);
        }

        public IEnumerable<UserDataContract> GetUsers()
        {
            return _service.GetUsers();
        }

        public bool RestoreUser(int id)
        {
            return _service.RestoreUser(id);
        }
    }
}
