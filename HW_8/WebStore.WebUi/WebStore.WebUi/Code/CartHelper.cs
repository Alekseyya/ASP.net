using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.WebUi.Models.Cart;

namespace WebStore.WebUi.Code
{
    public class CartHelper
    {
        private static string cartName = "cart";//авторизован или нет        

        public static bool TestUser()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                cartName = "cart " + System.Web.HttpContext.Current.User.Identity.Name;
                return true;
            }
            cartName = "cart ";
            return false;
        }
        
        public static Cart Cart
        {
            get
            {
                HttpCookie cookie = null;
                if (TestUser())
                    cookie = HttpContext.Current.Request.Cookies[cartName];
                else
                    cookie = HttpContext.Current.Request.Cookies[cartName];
                string json = string.Empty;
                Cart cart = null;
                if (cookie == null)
                {
                    cart = new Cart { Items = new List<CartItem>() };
                    json = JsonConvert.SerializeObject(cart);
                    cookie = new HttpCookie(cartName, json);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    return cart;
                }
                json = cookie.Value;
                cart = JsonConvert.DeserializeObject<Cart>(json);
                HttpContext.Current.Request.Cookies.Remove(cartName);
                HttpContext.Current.Response.Cookies.Remove(cartName);
                cookie = new HttpCookie(cartName, json);
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
                return cart;

            }
            set
            {

                string json = JsonConvert.SerializeObject(value);
                HttpCookie cookie = null;
                if (TestUser())
                    cookie = new HttpCookie(cartName, json);
                else
                    cookie = new HttpCookie(cartName, json);
                cookie.Expires = DateTime.Now.AddDays(1);

                HttpContext.Current.Request.Cookies.Remove(cartName);
                HttpContext.Current.Response.Cookies.Remove(cartName);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

        }
        //private static readonly string _cookieName = "cart" + (System.Web.HttpContext.Current.Request.IsAuthenticated ? System.Web.HttpContext.Current.User.Identity.Name : "");

        //public static Cart Cart
        //{
        //    get
        //    {

        //        var cookie = HttpContext.Current.Request.Cookies[_cookieName];
        //        string json = string.Empty;
        //        Cart cart = null;
        //        if (cookie == null)
        //        {
        //            cart = new Cart { Items = new List<CartItem>() };
        //            json = JsonConvert.SerializeObject(cart);
        //            cookie = new HttpCookie(_cookieName, json);
        //            cookie.Expires = DateTime.Now.AddDays(1);
        //            HttpContext.Current.Response.Cookies.Add(cookie);
        //            return cart;
        //        }
        //        json = cookie.Value;
        //        cart = JsonConvert.DeserializeObject<Cart>(json);
        //        HttpContext.Current.Request.Cookies.Remove(_cookieName);
        //        HttpContext.Current.Response.Cookies.Remove(_cookieName);
        //        cookie = new HttpCookie(_cookieName, json);
        //        cookie.Expires = DateTime.Now.AddDays(1);
        //        HttpContext.Current.Response.Cookies.Add(cookie);
        //        return cart;
        //    }
        //    set
        //    {
        //        string json = JsonConvert.SerializeObject(value);
        //        var cookie = new HttpCookie(_cookieName, json);
        //        cookie.Expires = DateTime.Now.AddDays(1);

        //        HttpContext.Current.Request.Cookies.Remove(_cookieName);
        //        HttpContext.Current.Response.Cookies.Remove(_cookieName);
        //        HttpContext.Current.Response.Cookies.Add(cookie);
        //    }
        //}
    }
}