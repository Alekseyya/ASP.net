using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUi.service;
using AutoMapper;
using WebStore.WebUi.Models;

namespace WebStore.WebUi.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            IEnumerable<IndexProductViewModel> product = null;
            using (var client = new service.ServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<service.ProductsService, IndexProductViewModel>());
                product = Mapper.Map<IEnumerable<service.ProductsService>, IEnumerable<IndexProductViewModel>>(client.GetListProducts());
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id.HasValue)
            {
                service.ProductsService prod;
                using (var client = new service.ServiceClient())
                {
                    prod = client.GetItemProduct((int)id);                    
                }
                return View(prod);
            }
            return View(new service.ProductsService());
        }

        [HttpPost]
        public ActionResult EditProduct(service.ProductsService prod)
        {
            if (ModelState.IsValid)
            {
                using (var client = new service.ServiceClient())
                {
                    client.UpdateProduct(prod);
                }
                
            }
            return RedirectToAction("Index");
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

        public ActionResult Delete(int id)
        {
            using (var client = new service.ServiceClient())
            {
                client.DeleteProduct(id);               
            }
            return RedirectToAction("Index");
        }
    }
}