using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUi.Models.Cart;

namespace WebStore.WebUi.Controllers
{
    public class CartController : Controller
    {
        private string cartName = "cart";//авторизован или нет

        private Cart Cart
        {
            get
            {
                var cookie = Request.Cookies[cartName];
                string json = string.Empty;
                Cart cart = null;
                if (cookie == null)
                {
                    cart = new Cart { Items = new List<CartItem>() };
                    json = JsonConvert.SerializeObject(cart);
                    cookie = new HttpCookie(cartName, json);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                    return cart;
                }
                json = cookie.Value;
                cart = JsonConvert.DeserializeObject<Cart>(json);
                Request.Cookies.Remove(cartName);
                Response.Cookies.Remove(cartName);
                cookie = new HttpCookie(cartName, json);
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                return cart;
            }
            set
            {
                string json = JsonConvert.SerializeObject(value);
                var cookie = new HttpCookie(cartName, json);
                cookie.Expires = DateTime.Now.AddDays(1);

                Request.Cookies.Remove(cartName);
                Response.Cookies.Remove(cartName);
                Response.Cookies.Add(cookie);
            }
        }
        public ActionResult Index()
        {
            return View("Index", TransformCart());
        }
        public ActionResult Details()
        {
            List<CardListDetailsView> list = new List<CardListDetailsView>();
            int number = 0;
            var aa = TransformCart().Items;
            foreach (var item in TransformCart().Items)
            {
                list.Add(new CardListDetailsView
                {
                    Id = item.Key.Id,
                    Number = number + 1,
                    NameProduct = item.Key.Name,
                    Price = item.Key.Price,
                    Descriptions = item.Key.Descriptions,
                    Count = item.Value,                    
                    Category = item.Key.Category
                });
            }
            return View("Details", new CartDetailsView { ListProduct = list, CountList= list.Count});
        }
        public ActionResult RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item.Count > 0)
                item.Count--;
            if (item.Count == 0)
                cart.Items.Remove(item);
            Cart = cart;
            return RedirectToAction("Details");
        }
        public ActionResult RemoveAll()
        {
            Cart = new Cart { Items = new List<CartItem>() };
            return RedirectToAction("Details");
        }
        public ActionResult AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
                item.Count++;
            else
                cart.Items.Add(new CartItem { ProductId = id, Count = 1 });
            Cart = cart;
            return RedirectToAction("Catalog", "Home");
        }
        private CartViewModel TransformCart()
        {
            using (var client = new service.ServiceClient())
            {
                var products = client.GetProducts();
                var r = new CartViewModel
                {
                    Items = Cart.Items.ToDictionary(x => products.First(y => y.Id == x.ProductId), x => x.Count)
                };
                return r;
            }

        }
    }
}