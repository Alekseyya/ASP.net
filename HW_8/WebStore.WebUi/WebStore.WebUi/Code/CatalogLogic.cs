using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.WebUi.Models;

namespace WebStore.WebUi.Code
{
    public class CatalogLogic
    {
        private CategoryViewModel Category { get; set; }
        private IEnumerable<IndexProductViewModel> Products { get; set; }
        public CatalogLogic(CategoryViewModel category, IEnumerable<IndexProductViewModel> indexProductViewModel)
        {
            Products = indexProductViewModel;
            Category = category;
        }
        public IEnumerable<IndexProductViewModel> GetListProducts()
        {
            if (Category.NameCategory == "Все")
                return Products;
            else
                return Products.Where(cat => cat.Category == Category.NameCategory);
        }

        public IEnumerable<IndexProductViewModel> AscendingPrice()
        {
            return Products.OrderBy(p => p.Price);
        }

        public List<IndexProductViewModel> AscendingPrice(IEnumerable<IndexProductViewModel> list)
        {
            if (!Category.Filter.PriceAscending)                
                return list.ToList();            
            return list.OrderBy(pr => pr.Price).ToList();
        }
        public List<IndexProductViewModel> ByName(IEnumerable<IndexProductViewModel> list)
        {
            if (!Category.Filter.ByName)
                return list.ToList();
            return list.OrderBy(pr => pr.Name).ToList();
        }

        public IEnumerable<IndexProductViewModel> PriceBoundary()
        {
            if (Category.Filter.PriceTo > 0 && Category.Filter.PriceFrom == 0) //если указана только цена до
                return Products.Where(pr => pr.Price <= Category.Filter.PriceTo);
            if (Category.Filter.PriceTo == 0 && Category.Filter.PriceFrom > 0) // если указана только цена после
                return Products.Where(pr => pr.Price >= Category.Filter.PriceFrom);
            if(Category.Filter.PriceTo > 0 && Category.Filter.PriceFrom > 0)
                return Products.Where(pr => pr.Price >= Category.Filter.PriceTo && pr.Price <= Category.Filter.PriceFrom);
            if (Category.Filter.PriceTo < 0 && Category.Filter.PriceFrom < 0)
                return Enumerable.Empty<IndexProductViewModel>();

            return Products;
        }

        public IEnumerable<IndexProductViewModel> PriceBoundary(IEnumerable<IndexProductViewModel> list)
        {
            if (Category.Filter.PriceTo > 0 && Category.Filter.PriceFrom == 0) //если указана только цена до
                return list.Where(pr => pr.Price <= Category.Filter.PriceTo);
            if (Category.Filter.PriceTo == 0 && Category.Filter.PriceFrom > 0) // если указана только цена после
                return list.Where(pr => pr.Price >= Category.Filter.PriceFrom);
            if (Category.Filter.PriceTo > 0 && Category.Filter.PriceFrom > 0)
                return list.Where(pr => pr.Price >= Category.Filter.PriceTo && pr.Price <= Category.Filter.PriceFrom).ToList();
            if (Category.Filter.PriceTo < 0 && Category.Filter.PriceFrom < 0)
                return Enumerable.Empty<IndexProductViewModel>();

            return list;
        }
    }
}