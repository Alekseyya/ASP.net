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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "OrderService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы OrderService.svc или OrderService.svc.cs в обозревателе решений и начните отладку.
    public class OrderService : IOrderService
    {
        private readonly IOrderService _service;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _service = new Services.Services.OrderService(unitOfWork);
        }


        #region OrderDetails
        public List<OrderDetailsDataContract> GetOrderDetails()
        {
            return _service.GetOrderDetails();
        }

        public OrderDetailsDataContract GetOrderDetailsById(int id)
        {
            return _service.GetOrderDetailsById(id);
        }
        public void UpdateOrderDetails(OrderDetailsDataContract order)
        {
            _service.UpdateOrderDetails(order);
        }
        public void DeleteOrderDetails(OrderDetailsDataContract order)
        {
            _service.DeleteOrderDetails(order);
        } 
        #endregion

        #region Order
        public List<OrderDataContract> GetOrders()
        {
            return _service.GetOrders();
        }
        public OrderDataContract GetOrderById(int id)
        {
            return _service.GetOrderById(id);
        }
        public void DeleteOrder(OrderDataContract order)
        {
            _service.DeleteOrder(order);
        }

        public void UpdateOrder(OrderDataContract order)
        {
            _service.UpdateOrder(order);
        } 
        #endregion


    }
}
