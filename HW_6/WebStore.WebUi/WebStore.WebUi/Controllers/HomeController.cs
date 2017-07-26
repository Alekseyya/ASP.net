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
                Mapper.Initialize(o => o.CreateMap<service.ProductDataContract, IndexProductViewModel>());
                product = Mapper.Map<IEnumerable<service.ProductDataContract>, IEnumerable<IndexProductViewModel>>(client.GetList());
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id.HasValue)
            {
                service.ProductDataContract prod;
                using (var client = new service.ServiceClient())
                {
                    prod = client.GetItem((int)id);                    
                }
                return View(prod);
            }
            return View(new service.ProductDataContract());
        }

        [HttpPost]
        public ActionResult EditProduct(service.ProductDataContract prod)
        {
            //if (ModelState.IsValid)
            //{
            //    using (var client = new service.ServiceClient())
            //    {
            //        client.u(prod);
            //    }
                
            //}
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            //using (var client = new service.ServiceClient())
            //{
            //    var prod = client.GetItemProduct(id);
            //    if (prod != null)
            //    {
            //        return View(prod);
            //    }

            //}

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //using (var client = new service.ServiceClient())
            //{
            //    client.DeleteProduct(id);               
            //}
            return RedirectToAction("Index");
        }
    }
}