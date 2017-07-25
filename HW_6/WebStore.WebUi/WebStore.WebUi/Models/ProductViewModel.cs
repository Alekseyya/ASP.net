using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models
{
    public class IndexProductViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name= "Имя товара")]
        public string Name { get; set; }

        [Display(Name= "Количество")]
        public int Count { get; set; }
    }
    public class CreateProductViewModel
    {
        public int MyProperty { get; set; }
    }

    public class EditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}