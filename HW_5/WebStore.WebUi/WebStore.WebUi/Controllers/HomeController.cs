using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUi.service;

namespace WebStore.WebUi.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var prodList = new List<service.Products>();
            using (var client = new service.ServiceClient())
            {
                foreach (var prod in client.GetListProducts())
                {
                    prodList.Add(new Products { Id = prod.Id, Name = prod.Name, Count = prod.Count });
                }
                ViewBag.Message = prodList;
                
            }
            return View(prodList);
        }

        public ActionResult Details(int id)
        {
            using (var client = new service.ServiceClient())
            {
                var prod = client.GetItemProduct(id);
                if (prod != null)
                {
                    return View(prod);
                }

            }

            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}