using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUi.AuthenticationService;
using WebStore.WebUi.Models.Cart;
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

        public ActionResult AddToOrder(string products) //посмотреть если методы добававления в заказ
        {

            
            int userId = 0;
            using (var user = new AuthenticationServiceClient())
            {
                userId = user.GetUserByName(User.Identity.Name).Id;
            }

            using (var client = new OrderServiceClient())
            {
                //Получаем все заказы                
                var lastId = 0;
                if (client.GetOrders().LastOrDefault() == null)
                {
                    lastId = 1;
                }
                else { lastId = client.GetOrders().Max(id => id.Id)+1; }
                //Сериализация строки в класс
                List<CardListDetailsView> resultSerialProducts = System.Web.Helpers.Json.Decode<List<CardListDetailsView>>(products);
                //Создание заказа

                OrderService.OrderDataContract newOrder = new OrderService.OrderDataContract
                {
                    //пойти в базуб получить id
                    Id = lastId,
                    User = User.Identity.Name,
                    OrderDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                             DateTime.Now.Day, DateTime.Now.Hour,
                                             DateTime.Now.Minute, DateTime.Now.Second),
                    OrderPrice = ((Func<decimal>)(() =>
                    {
                        decimal price = 0;
                        foreach (var prod in resultSerialProducts)
                        {
                            var tmp = prod.Price * prod.Count;
                            price += tmp;
                        }
                        return price;
                    }))()
                };
                //Добавление в бд новый заказ
                client.AddOrder(newOrder);


                //заполнение нового заказа
                List<OrderDetailsDataContract> orderDetails = new List<OrderDetailsDataContract>();
                foreach (var item in resultSerialProducts)
                {
                    orderDetails.Add(new OrderDetailsDataContract
                    {
                        Id = item.Id,
                        Product = item.NameProduct,
                        OrderId = newOrder.Id,
                        Quantity = item.Count,
                        TotalPrice = item.Price
                    }); 
                }
                //добавление в бд деталей заказа
                //client.AddOrderDetails(orderDetails);
                client.AddOrderDetails(orderDetails.ToArray());
            };
            return RedirectToAction("Catalog", "Home");
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