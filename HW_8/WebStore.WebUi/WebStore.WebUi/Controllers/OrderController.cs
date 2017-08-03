using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore.WebUi.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index() //Информация о заказе
        {
            //using (var client = new OrderService) // получаем данные заказа
            //{

            //}
            return View(); //new ienumerableUserorderViewModel
        }
        public ActionResult OrderHistoryDetails(int id, DateTime orderDate)
        {

            return View(); //UserOrderDetailsViewModel
        }
    }
}