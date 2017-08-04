using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUi.AuthenticationService;

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

        public IEnumerable<SelectListItem> GroupList
        {
            get
            {
                List<SelectListItem> tmpList = new List<SelectListItem>();
                using (var admin = new AuthenticationServiceClient())  //вот так мне кажется непрвильно, это как-то надо перенести в 
                {                                                 // в контроллер
                    foreach (var item in admin.GetGroups()) // для задания можно добавить просто пустой первый
                    {
                        tmpList.Add(new SelectListItem { Text = item.Name, Value = item.Name });
                    }
                }
                return tmpList.Select(l => new SelectListItem { Selected = (l.Value == Group), Text = l.Text, Value = l.Value });
            }

        }
    }
}