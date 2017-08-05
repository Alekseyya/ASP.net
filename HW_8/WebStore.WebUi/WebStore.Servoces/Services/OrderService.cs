using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.DataContracts.Service;
using WebStore.Domain.Entities;
using WebStore.Services.Services.Base;

namespace WebStore.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region OrderDetails
        public void AddOrderDetails(List<OrderDetailsDataContract> order)
        {
            Mapper.Initialize(o => o.CreateMap<OrderDetailsDataContract, OrderDetails>()
                    .ForMember("Product", opt => opt.Ignore())
                    .ForMember(om => om.ProductId, opt => opt.MapFrom(c => c.Id)));
            var orderMap = Mapper.Map<IEnumerable<OrderDetailsDataContract>, IEnumerable<OrderDetails>>(order);
            List<OrderDetails> ordersMap = new List<OrderDetails>();
            foreach (var item in orderMap)
            {
                ordersMap.Add(new OrderDetails
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    OrderId = item.OrderId
                });
            }
            //по имени
            _unitOfWork.OrderDetailsRepository.Create(ordersMap);
        }
        public List<OrderDetailsDataContract> GetOrderDetails()
        {
            Mapper.Initialize(o => o.CreateMap<OrderDetails, OrderDetailsDataContract>()
                    .ForMember("Product", opt => opt.MapFrom(c => c.Product.Name)));
            var orderDetails = Mapper.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailsDataContract>>(_unitOfWork.OrderDetailsRepository.GetList());
            foreach (var item in orderDetails)
            {
                item.TotalPrice = _unitOfWork.ProductRepository.GetList().FirstOrDefault(p => p.Name == item.Product).Price;
            }
            return orderDetails.ToList();
        }

        public OrderDetailsDataContract GetOrderDetailsById(int id)
        {
            Mapper.Initialize(o => o.CreateMap<OrderDetails, OrderDetailsDataContract>()
                    .ForMember("Product", opt => opt.MapFrom(c => c.Product.Name)));
            var orderDetails = Mapper.Map<OrderDetails, OrderDetailsDataContract>(_unitOfWork.OrderDetailsRepository.GetItem(id));
            return orderDetails;
        }
        public void UpdateOrderDetails(OrderDetailsDataContract order)
        {
            throw new NotImplementedException();
        }
        public void DeleteOrderDetails(OrderDetailsDataContract order)
        {
            _unitOfWork.OrderDetailsRepository.Delete(order.Id);
        }
        #endregion

        #region Order
        public void AddOrder(OrderDataContract order)
        {
            Mapper.Initialize(o => o.CreateMap<OrderDataContract, Order>()
                    .ForMember("User", opt => opt.Ignore()));
            var orderMap = Mapper.Map<OrderDataContract, Order>(order);
            orderMap.UserId = _unitOfWork.UserRepository.GetItemByName(order.User).Id;
            _unitOfWork.OrderRepository.Create(orderMap);
        }
        public IEnumerable<OrderDataContract> GetOrders()
        {
            Mapper.Initialize(o => o.CreateMap<Order, OrderDataContract>()
                    .ForMember("User", opt => opt.MapFrom(c => c.User.Name)));
            var order = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDataContract>>(_unitOfWork.OrderRepository.GetList());
                       
            return order.ToList();
        }
        public OrderDataContract GetOrderById(int id)
        {
            Mapper.Initialize(o => o.CreateMap<Order, OrderDataContract>()
                    .ForMember("User", opt => opt.MapFrom(c => c.User.Name)));
            var orderDetails = Mapper.Map<Order, OrderDataContract>(_unitOfWork.OrderRepository.GetItem(id));
            return orderDetails;
        }
        public void DeleteOrder(OrderDataContract order)
        {
            _unitOfWork.OrderRepository.Delete(order.Id);
        }


        public void UpdateOrder(OrderDataContract order)
        {
            throw new NotImplementedException();
        }
        
        #endregion


    }
}
