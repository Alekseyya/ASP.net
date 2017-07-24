using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebStore.Domain.DataContracts.Service;
using WebStore.Services.Services.Base;

namespace WebStore.Hosting
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService
    {
        private readonly IService _service;
        public Service1()
        {
            _service = new Services.Services.Service();
        }

        public void CreateProduct(ProductsService item)
        {
            _service.CreateProduct(item);
        }

        public void DeleteProduct(int id)
        {
            _service.DeleteProduct(id);
        }

        public ProductsService GetItemProduct(int id)
        {
            return _service.GetItemProduct(id);
        }

        public List<ProductsService> GetListProducts()
        {
            return _service.GetListProducts();
        }

        public void UpdateProduct(ProductsService item)
        {
            _service.UpdateProduct(item);
        }
        //public string GetData(int value)
        //{
        //    return _service.GetData(value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    return _service.GetDataUsingDataContract(composite);
        //}
    }
}
