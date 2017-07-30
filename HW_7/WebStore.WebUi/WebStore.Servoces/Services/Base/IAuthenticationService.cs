using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
    }
}
