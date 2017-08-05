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
    public class OrderRepository : IOrderRepository
    {
        private readonly WebStoreContext _context;
        public OrderRepository(WebStoreContext context)
        {
            _context = context;
        }
        public void Create(Order item)
        {            
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Id == id);
            var ordersDetails = _context.OrderDetails.Where(o => o.OrderId == order.Id);
            foreach (var item in ordersDetails)
            {
                _context.OrderDetails.Remove(item);
            }           
            _context.Orders.Remove(order);

        }

        public Order GetItem(int id)
        {
            return _context.Orders.Include("User").FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetList()
        {
            return _context.Orders.Include("User").ToArray(); 
        }

        public void Update(Order item)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == item.Id);
            bool isModified = false;

            if (order.UserId != item.UserId)
            {
                order.UserId = item.UserId;
                isModified = true;
            }

            if (order.OrderDate != item.OrderDate)
            {
                order.OrderDate = item.OrderDate;
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
