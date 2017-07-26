using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models
{
    public class CategoryViewModel
    {
        [Display(Name= "Id")]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}