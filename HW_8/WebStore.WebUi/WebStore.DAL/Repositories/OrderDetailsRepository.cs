using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly WebStoreContext _context;
        public OrderDetailsRepository(WebStoreContext context)
        {
            _context = context;
        }
        public void Create(OrderDetails item)
        {
            _context.OrderDetails.Add(item);
        }

        public void Delete(int id)
        {
            OrderDetails orderDetails = _context.OrderDetails.FirstOrDefault(o => o.Id == id);
            _context.OrderDetails.Remove(orderDetails);
        }
         
        public OrderDetails GetItem(int id)
        {
            return _context.OrderDetails.Include("Product")
                                        .Include("Order")
                                        .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<OrderDetails> GetList()
        {
            return _context.OrderDetails.Include("Product")
                                        .Include("Order").ToArray();
        }

        public void Update(OrderDetails item)
        {
            var order = _context.OrderDetails.FirstOrDefault(o => o.Id == item.Id);
            bool isModified = false;

            if (order.OrderId != item.OrderId)
            {
                order.OrderId = item.OrderId;
                isModified = true;
            }

            if (order.ProductId != item.ProductId)
            {
                order.ProductId = item.ProductId;
                isModified = true;
            }

            if (order.Quantity != item.Quantity)
            {
                order.Quantity = item.Quantity;
                isModified = true;
            }
            if (order.Quantity != item.Quantity)
            {
                order.Quantity = item.Quantity;
                isModified = true;
            }

            if (isModified)
            {
                _context.Entry(order).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
