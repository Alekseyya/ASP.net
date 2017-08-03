using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.DataContracts.Service;
using WebStore.Domain.Entities;
using WebStore.Services.Services.Base;

namespace WebStore.Hosting
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService
    {
        private readonly IService _service;
       
        public Service1(IUnitOfWork repository)
        {
            _service = new Services.Services.Service(repository);
        }

        

        public IEnumerable<CategoryDataContract> GetCategories()
        {
            return _service.GetCategories();
        }

        public CategoryDataContract GetCategory(string name)
        {
            return _service.GetCategory(name);
        }

        public CategoryDataContract GetCategory(int id)
        {
            return _service.GetCategory(id);
        }

        public ProductDataContract GetProduct(int id)
        {
            return _service.GetProduct(id);
        }
        public void UpdateProduct(ProductDataContract product)
        {
            _service.UpdateProduct(product);
        }

        public List<ProductDataContract> GetProducts()
        {
            return _service.GetProducts();
        }

        

       

        #region oldService
        //private readonly IService _service;
        //public Service1()
        //{
        //    _service = new Services.Services.Service();
        //}

        //public void CreateProduct(ProductDataContract item)
        //{
        //    _service.CreateProduct(item);
        //}

        //public void DeleteProduct(int id)
        //{
        //    _service.DeleteProduct(id);
        //}

        //public ProductDataContract GetItemProduct(int id)
        //{
        //    return _service.GetItemProduct(id);
        //}

        //public List<ProductDataContract> GetListProducts()
        //{
        //    return _service.GetListProducts();
        //}

        //public void UpdateProduct(ProductDataContract item)
        //{
        //    _service.UpdateProduct(item);
        //} 
        #endregion

    }
}
