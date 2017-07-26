using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.DataContracts.Service;

namespace WebStore.Services.Services.Base
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        List<ProductDataContract> GetList();

        [OperationContract]
        ProductDataContract GetItem(int id);
        
    }
}
