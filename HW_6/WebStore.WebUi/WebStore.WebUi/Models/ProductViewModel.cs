using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore.WebUi.Models
{
    public class IndexProductViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name= "Имя товара")]
        public string Name { get; set; }

        [Display(Name="Описание")]
        public string Descriptions { get; set; }
        [Display(Name= "Количество")]
        public int Count { get; set; }
    }
    public class CreateProductViewModel
    {
        public int MyProperty { get; set; }
    }

    public class EditProductViewModel //не знаю как правильно передать метод сюда.
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Descriptions { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        public IEnumerable<SelectListItem> CategoryList
        {
            get
            {
                List<SelectListItem> tmpList = new List<SelectListItem>();
                using (var client = new service.ServiceClient())  //вот так мне кажется непрвильно, это как-то надо перенести в 
                {                                                 // в контроллер
                    foreach (var item in client.GetCategories()) // для задания можно добавить просто пустой первый
                    {
                        tmpList.Add(new SelectListItem { Text = item.Name, Value = item.Name });
                    }
                }                
                return tmpList.Select(l => new SelectListItem { Selected = (l.Value == Category), Text = l.Text, Value = l.Value });
            }

        }
    }
}