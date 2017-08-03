using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUi.Models.Order;
using WebStore.WebUi.OrderService;

namespace WebStore.WebUi.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index() //Информация о заказе
        {
            List<UserOrderViewModel> orders = new List<UserOrderViewModel>();
            using (var client = new OrderServiceClient()) // получаем данные заказа
            {
                foreach (var order in client.GetOrders().Where(u=>u.User == System.Web.HttpContext.Current.User.Identity.Name))
                {
                    orders.Add(new UserOrderViewModel
                    {
                        Id = order.Id,
                        UserName = order.User,
                        OrderPrice = order.OrderPrice,
                        OrderDate = order.OrderDate
                     });
                }                
            }
            return View(orders.AsEnumerable()); 
        }
        public ActionResult OrderHistoryDetails(DateTime? orderDate) //id - номер заказа
        {
            
            UserOrderDetailsViewModel orderDetails = new UserOrderDetailsViewModel();
            List<UserOrderDetailsItem> orderDetailsItems = new List<UserOrderDetailsItem>();
            using (var client = new OrderServiceClient()) // получаем данные заказа
            {
                //надо найти сам заказа
                var order = client.GetOrders().FirstOrDefault(o => o.OrderDate == orderDate);
                orderDetails.Id = order.Id;
                orderDetails.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                orderDetails.OrderPrice = order.OrderPrice;
                orderDetails.Details = new Func<IEnumerable<UserOrderDetailsItem>>(() =>
                    {
                        foreach (var orderItem in client.GetOrderDetails().Where(o => o.OrderId == order.Id))
                        {
                            orderDetailsItems.Add(new UserOrderDetailsItem
                            {
                                Id = orderItem.Id,
                                ProductName = orderItem.Product,
                                Quantity = orderItem.Quantity,
                                TotalPrice = orderItem.TotalPrice
                            });
                        }
                        return orderDetailsItems.AsEnumerable();
                    })();
                

            }            
            return View(orderDetails); //UserOrderDetailsViewModel
        }
    }
}