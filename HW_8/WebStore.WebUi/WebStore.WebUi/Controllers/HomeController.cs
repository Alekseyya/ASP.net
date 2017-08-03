using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUi.service;
using AutoMapper;
using WebStore.WebUi.Models;
using WebStore.WebUi.Code;

namespace WebStore.WebUi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public bool ModalShowed
        {
            get
            {
                if (Session["ModalShowed"] == null)
                    return false;
                return (bool)Session["ModalShowed"];
            }
            set { Session["ModalShowed"] = value; }
        }

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

        [Authorize]
        [HttpGet]
        public ActionResult Catalog()
        {
            ViewBag.ShowModal = false;
            if (CartHelper.Cart.ItemsCount > 0 && !ModalShowed)
            {
                ViewBag.ShowModal = true;
                ModalShowed = true;
            }
            IEnumerable<IndexProductViewModel> products;                     
            using (var client = new service.ServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<service.ProductDataContract, IndexProductViewModel>());
                products = Mapper.Map<IEnumerable<service.ProductDataContract>, IEnumerable<IndexProductViewModel>>(client.GetProducts());
                
            }
            ViewBag.UserInfo = new UserViewModel { IsAuthenticated = User.Identity.IsAuthenticated, UserName = User.Identity.Name };
            ViewBag.Products = products;
            ///CatalogLogic logic = new CatalogLogic(new CategoryViewModel { ListProduct = products }, products);
            return View(new CategoryViewModel { ListProduct = products });
        }

        public ActionResult Partial()
        {
            return PartialView();
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

            CatalogLogic logic = new CatalogLogic(category, products);
            IEnumerable<IndexProductViewModel> productList = logic.GetListProducts(); //допустим пришло ВСЕ
            
            var prodListConditionPrice = logic.PriceBoundary(productList); //учитывает все условия по цене
            if(category.Filter.PriceAscending == true)
            {
                var prodList = logic.AscendingPrice(prodListConditionPrice); //учитываем переключалку цены(по возрастанию)
                return View(new CategoryViewModel
                {
                    Id = category.Id,
                    NameCategory = category.NameCategory,
                    Filter = new FilterModel
                    {
                        PriceAscending = true,
                        ByName = false,
                        PriceTo = category.Filter.PriceTo,
                        PriceFrom = category.Filter.PriceFrom
                    },                    
                    ListProduct = prodList.AsEnumerable()
                });
            }  else if(category.Filter.ByName == true)
            {
                var prodListByName = logic.ByName(prodListConditionPrice);
                return View(new CategoryViewModel
                {
                    Id = category.Id,
                    NameCategory = category.NameCategory,
                    Filter = new FilterModel
                    {
                        PriceAscending = false,
                        ByName = true,
                        PriceTo = category.Filter.PriceTo,
                        PriceFrom = category.Filter.PriceFrom
                    },
                    ListProduct = prodListByName.AsEnumerable()
                });
            }          
            //var prodList = logic.AscendingPrice(prodListConditionPrice); //учитываем переключалку цены(по возрастанию)
            //var prodListByName = logic.ByName(prodList);
            return View( new CategoryViewModel { ListProduct = prodListConditionPrice.AsEnumerable() });
            

            #region Правильный вариант
            //if (category.NameCategory == "Все")
            //{
            //    ViewBag.Products = products;
            //    if (category.PriceAscending == true && category.PriceTo==0)
            //        ViewBag.Products = products.OrderBy(u => u.Price);
            //    if(category.PriceAscending == true && category.PriceTo > 0)
            //    {
            //        ViewBag.Products = products.Where(p => p.Price <= category.PriceTo)
            //                                   .OrderBy(u => u.Price);
            //    }else if (category.PriceAscending == false && category.PriceTo > 0)
            //    {
            //        ViewBag.Products = products.Where(p => p.Price <= category.PriceTo);
            //    }
            //    //Цены
            //    if (category.PriceTo == 0 && category.PriceFrom != 0)
            //    {
            //        ViewBag.Products = products.Where(p => p.Price >= category.PriceFrom)
            //                                       .OrderBy(u => u.Price);
            //    }
            //    else if (category.PriceTo != 0 && category.PriceFrom != 0)
            //    {
            //        ViewBag.Products = products.Where(p => p.Price >= category.PriceTo && p.Price <= category.PriceFrom)
            //                                       .OrderBy(u => u.Price);
            //    }

            //    return View(category);
            //}

            //ViewBag.Products = products.ToList().FindAll(cat => cat.Category == category.NameCategory);
            //if (category.PriceAscending == true && category.PriceTo == 0)
            //    ViewBag.Products = products.ToList().FindAll(cat => cat.Category == category.NameCategory)
            //                               .OrderBy(u => u.Price);
            //if (category.PriceAscending == true && category.PriceTo > 0)
            //{
            //    ViewBag.Products = products.ToList().FindAll(cat => cat.Category == category.NameCategory)
            //                               .Where(p => p.Price <= category.PriceTo)
            //                               .OrderBy(u => u.Price);
            //}
            //else if (category.PriceAscending == false && category.PriceTo > 0)
            //{
            //    ViewBag.Products = products.ToList().FindAll(cat => cat.Category == category.NameCategory)
            //                               .Where(p => p.Price <= category.PriceTo);
            //}

            ////Категории до и после
            //if(category.PriceTo == 0 && category.PriceFrom!=0)
            //{
            //    ViewBag.Products = products.Where(p => p.Price >= category.PriceFrom && p.Category == category.NameCategory)
            //                                   .OrderBy(u => u.Price);
            //} else if (category.PriceTo !=0 && category.PriceFrom != 0)
            //{
            //    ViewBag.Products = products.Where(p => p.Price >= category.PriceTo && p.Price <= category.PriceFrom 
            //                                                                         && p.Category == category.NameCategory)
            //                                   .OrderBy(u => u.Price);
            //} 
            #endregion

            
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