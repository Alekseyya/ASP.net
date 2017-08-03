using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Areas.Admin.Models
{
    public class UserViewModel
    {
        [Display(Name="Id пользователя")]
        public int Id { get; set; }
        
        [Display(Name="Имя пользователя")]
        public string Name { get; set; }
        [Display(Name ="Пароль")]
        public string Password { get; set; }
        [Display(Name ="Удален")]
        public bool IsDeleted { get; set; }

        [Display(Name ="Группа пользователя")]
        public string Group { get; set; }
    }
}