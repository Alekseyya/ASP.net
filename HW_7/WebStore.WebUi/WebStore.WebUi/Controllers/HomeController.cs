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
        
        public ActionResult ProductList()
        {
            IEnumerable<IndexProductViewModel> product = null;
            using (var client = new service.ServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<service.ProductDataContract, IndexProductViewModel>());
                product = Mapper.Map<IEnumerable<service.ProductDataContract>, IEnumerable<IndexProductViewModel>>(client.GetProducts());
            }

            return View(product);
        }
        

        [HttpGet]
        public ActionResult Catalog()
        {
            IEnumerable<IndexProductViewModel> products;                     
            using (var client = new service.ServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<service.ProductDataContract, IndexProductViewModel>());
                products = Mapper.Map<IEnumerable<service.ProductDataContract>, IEnumerable<IndexProductViewModel>>(client.GetProducts());
                
            }
            ViewBag.Products = products;
            return View(new CategoryViewModel());
        }

        [HttpPost]
        public ActionResult Catalog(CategoryViewModel category)
        {
            IEnumerable<IndexProductViewModel> products;           
            using (var client = new service.ServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<service.ProductDataContract, IndexProductViewModel>());
                products = Mapper.Map<IEnumerable<service.ProductDataContract>, IEnumerable<IndexProductViewModel>>(client.GetProducts());
                
            }
            if (category.NameCategory == "Все")
            {
                ViewBag.Products = products;
                if (category.PriceAscending == true && category.Price==0)
                    ViewBag.Products = products.OrderBy(u => u.Price);
                if(category.PriceAscending == true && category.Price > 0)
                {
                    ViewBag.Products = products.Where(p => p.Price <= category.Price)
                                               .OrderBy(u => u.Price);
                }else if (category.PriceAscending == false && category.Price > 0)
                {
                    ViewBag.Products = products.Where(p => p.Price <= category.Price);
                }
                
                return View(category);
            }

            ViewBag.Products = products.ToList().FindAll(cat => cat.Category == category.NameCategory);
            if (category.PriceAscending == true && category.Price == 0)
                ViewBag.Products = products.ToList().FindAll(cat => cat.Category == category.NameCategory)
                                           .OrderBy(u => u.Price);
            if (category.PriceAscending == true && category.Price > 0)
            {
                ViewBag.Products = products.ToList().FindAll(cat => cat.Category == category.NameCategory)
                                           .Where(p => p.Price <= category.Price)
                                           .OrderBy(u => u.Price);
            }
            else if (category.PriceAscending == false && category.Price > 0)
            {
                ViewBag.Products = products.ToList().FindAll(cat => cat.Category == category.NameCategory)
                                           .Where(p => p.Price <= category.Price);
            }


            return View(category);
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
        public ActionResult EditProduct(EditProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                using (var client = new service.ServiceClient()) //преобразовать в ProductDataContract
                {
                    Mapper.Initialize(o => o.CreateMap<EditProductViewModel, service.ProductDataContract>());
                    service.ProductDataContract prod = Mapper.Map<EditProductViewModel, service.ProductDataContract>(product);
                    client.UpdateProduct(prod);
                }

            }
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