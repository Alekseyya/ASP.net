using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebStore.DAL.Repositories.Base;
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

        public bool RegisterUser(string userName, string userPassword)
        {
            return _service.RegisterUser(userName, userPassword);
        }
    }
}
