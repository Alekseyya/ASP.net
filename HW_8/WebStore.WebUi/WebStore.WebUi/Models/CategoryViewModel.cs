﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore.WebUi.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Filter = new FilterModel();
        }
        public int Id { get; set; }
        [Display(Name = "Категория")]
        public string NameCategory { get; set; }

        public IEnumerable<IndexProductViewModel> ListProduct { get; set; }
        public FilterModel Filter { get; set; }
        //public IEnumerable<SelectListItem> _listItems { get; set; }

        public IEnumerable<SelectListItem> ListName
        {
            get
            {
                
                    List<SelectListItem> tmpList = new List<SelectListItem>();
                    using (var client = new service.ServiceClient())
                    {
                        tmpList.Add(new SelectListItem { Text = "Все", Value = "Все" });
                        foreach (var item in client.GetCategories())
                        {
                            tmpList.Add(new SelectListItem { Text = item.Name, Value = item.Name });
                        }
                    }
                    return tmpList.Select(l => new SelectListItem { Selected = (l.Value == NameCategory), Text = l.Text, Value = l.Value });
                
            }

        }
    }

    public class FilterModel
    {

        [Display(Name = "По возрастанию")]
        public bool PriceAscending { get; set; }

        [Display(Name = "Цена до")]
        [UIHint("Decimal")]
        public decimal PriceTo { get; set; }

        [Display(Name = "Цена после")]
        [UIHint("Decimal")]
        public decimal PriceFrom { get; set; }
        [Display(Name = "Сортировка по имени")]
        public bool ByName { get; set; }
    }
}