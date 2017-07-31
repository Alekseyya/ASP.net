using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.WebUi.Models;

namespace WebStore.WebUi.Code
{
    static class CatalogLogic
    {
        static public CategoryViewModel Ascending(string categoryName)
        {
            IEnumerable<IndexProductViewModel> products;
            using (var client = new service.ServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<service.ProductDataContract, IndexProductViewModel>());
                products = Mapper.Map<IEnumerable<service.ProductDataContract>, IEnumerable<IndexProductViewModel>>(client.GetProducts());

            }
            var productsTmp = products.Where(cat => cat.Category == categoryName).OrderBy(p=>p.Price);
            //using (var client = new service.ServiceClient())
            //{
            //    Mapper.Initialize(o => o.CreateMap<IndexProductViewModel, CategoryViewModel>());
            //    products = Mapper.Map<IEnumerable<IndexProductViewModel>, IEnumerable<CategoryViewModel>>(client.GetProducts());
            //}

            return null;
        }
    }
}