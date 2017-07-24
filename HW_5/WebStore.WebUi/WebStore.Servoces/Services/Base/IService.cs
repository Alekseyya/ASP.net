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
        List<ProductsService> GetListProducts();
        [OperationContract]
        ProductsService GetItemProduct(int id);
        [OperationContract]
        void CreateProduct(ProductsService item);
        [OperationContract]
        void DeleteProduct(int id);
        [OperationContract]
        void UpdateProduct(ProductsService item);


    }
}
