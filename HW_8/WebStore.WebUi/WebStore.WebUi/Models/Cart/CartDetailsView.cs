using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models.Cart
{
    public class CartDetailsView
    {
        public List<CardListDetailsView> ListProduct { get; set; }
        public int CountList { get; set; }
        
    }
    public class CardListDetailsView
    {
        [Display(Name = "Номер товара")]
        public int Number { get; set; }
        [Display(Name ="Id товара")]
        public int Id { get; set; }
        [Display(Name = "Наименование продукта")]
        public string NameProduct { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Описание")]
        public string Descriptions { get; set; }
        [Display(Name ="Количество")]
        public int Count { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
    }
}