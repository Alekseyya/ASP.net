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
        public List<OrderDetailsDataContract> GetOrderDetails()
        {
            Mapper.Initialize(o => o.CreateMap<OrderDetails, OrderDetailsDataContract>()
                    .ForMember("Product", opt => opt.MapFrom(c => c.Product.Name)));
            var orderDetails = Mapper.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailsDataContract>>(_unitOfWork.OrderDetailsRepository.GetList());
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
        public List<OrderDataContract> GetOrders()
        {
            throw new NotImplementedException();
        }
        public OrderDataContract GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
        public void DeleteOrder(OrderDataContract order)
        {
            throw new NotImplementedException();
        }


        public void UpdateOrder(OrderDataContract order)
        {
            throw new NotImplementedException();
        } 
        #endregion


    }
}
