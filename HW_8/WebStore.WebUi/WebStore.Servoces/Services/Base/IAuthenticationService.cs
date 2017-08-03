using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebStore.Domain.DataContracts.Service;

namespace WebStore.Services.Services.Base
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IAuthenticationService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        bool CheckUser(string userName, string userPassword);

        [OperationContract]
        bool RegisterUser(string userName, string userPassword);

        [OperationContract]
        IEnumerable<GroupDataContract> GetGroups();

        [OperationContract]
        bool UserInGroup(string userName, string groupName);

        [OperationContract]
        GroupDataContract GetGroupById(int id);

        [OperationContract]
        void UpdateGroup(GroupDataContract group);

        [OperationContract]
        void DeleteGroup(int id);



        [OperationContract]
        IEnumerable<UserDataContract> GetUsers();

        [OperationContractAttribute(Name = "GetUserById")]
        UserDataContract GetUser(int id);

        [OperationContractAttribute(Name = "GetUserByName")]
        UserDataContract GetUser(string name);

        [OperationContract]
        bool AddUser(UserDataContract user);

        [OperationContract]
        bool EditUser(UserDataContract user);

        [OperationContract]
        bool DeleteUser(int id);

        [OperationContract]
        bool RestoreUser(int id);
    }
}
