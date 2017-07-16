using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class AuthentificationParams
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(1, ErrorMessage = "Длина логина должна быть не менее 1.")]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(1, ErrorMessage = "Длина пароля должна быть не менее 1.")]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

    }
}