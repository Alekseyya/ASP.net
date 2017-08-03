using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.DataContracts.Service;
using WebStore.Domain.Entities;

namespace WebStore.Services.Services.Base
{
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// Полсучить список продуктов
        /// </summary>
        /// <returns>List<ProductDataContract></returns>
        [OperationContract]
        List<ProductDataContract> GetProducts();

        /// <summary>
        /// Получить товар по id
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns>ProductDataContract</returns>
        [OperationContract]
        ProductDataContract GetProduct(int id);

        [OperationContract]
        void UpdateProduct(ProductDataContract product);

        [OperationContract]
        IEnumerable<CategoryDataContract> GetCategories();

        //[OperationContract(Name = "GetCategoryById")]
        [OperationContractAttribute(Name ="GetCategoryById")]
        CategoryDataContract GetCategory(int id);

        [OperationContractAttribute(Name = "GetCategoryByName")]
        CategoryDataContract GetCategory(string name);

        

        #region Future
        //[OperationContract]
        //IEnumerable<Group> GetGroups();

        //[OperationContract]
        //Group GetGroup(int id);

        //[OperationContract]
        //Group GetGroup(string name);

        //[OperationContract]
        //IEnumerable<Order> GetOrders();

        //[OperationContract]
        //Order GetOrder(int id);

        //[OperationContract]
        //IEnumerable<OrderDetail> GetOrderDetails();

        //[OperationContract]
        //IEnumerable<OrderDetail> GetOrderDetails(Func<OrderDetail, bool> func);

        //[OperationContract]
        //bool AddOrder(Order order);

        //[OperationContract]
        //bool AddOrderDetails(IEnumerable<OrderDetail> orderDetails); 
        #endregion
        
    }
}
