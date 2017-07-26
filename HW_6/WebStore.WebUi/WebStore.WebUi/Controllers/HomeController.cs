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
                product = Mapper.Map<IEnumerable<service.ProductDataContract>, IEnumerable<IndexProductViewModel>>(client.GetProducts());
            }
            return View(product);
        }

        public ActionResult Categories()
        {
            IEnumerable<CategoryViewModel> categories;
            using (var client = new service.ServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<service.CategoryDataContract, CategoryViewModel>());
                categories = Mapper.Map<IEnumerable<service.CategoryDataContract>, IEnumerable<CategoryViewModel>>(client.GetCategories());

            }
            return View(categories);
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id.HasValue)
            {
                EditProductViewModel product = null;
                using (var client = new service.ServiceClient())
                {
                    Mapper.Initialize(o => o.CreateMap<service.ProductDataContract, EditProductViewModel>());
                    product = Mapper.Map<service.ProductDataContract, EditProductViewModel>(client.GetProduct((int)id));
                }
                return View(product);
            }

            return View(new EditProductViewModel());           
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