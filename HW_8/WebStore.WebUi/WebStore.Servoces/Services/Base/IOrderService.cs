using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebStore.Domain.DataContracts.Service;

namespace WebStore.Services.Services.Base
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IOrderService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IOrderService
    {
        #region Order
        [OperationContract]
        void AddOrder(OrderDataContract order);
        [OperationContract]
        IEnumerable<OrderDataContract> GetOrders();

        [OperationContract]
        OrderDataContract GetOrderById(int id);

        [OperationContract]
        void UpdateOrder(OrderDataContract order);

        [OperationContract]
        void DeleteOrder(OrderDataContract order);
        #endregion

        #region OrderDetails
        [OperationContract]
        void AddOrderDetails(List<OrderDetailsDataContract> order);

        [OperationContract]
        List<OrderDetailsDataContract> GetOrderDetails();

        [OperationContract]
        OrderDetailsDataContract GetOrderDetailsById(int id);

        [OperationContract]
        void UpdateOrderDetails(OrderDetailsDataContract order);

        [OperationContract]
        void DeleteOrderDetails(OrderDetailsDataContract order); 
        #endregion
    }
}
