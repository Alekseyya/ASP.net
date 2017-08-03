using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models
{
    public class AuthenticationParamsViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Логин является обязательным для заполнения")]
        [MinLength(3, ErrorMessage = "Введите хотя бы 3 символа")]
        public string User { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пароль является обязательным для заполнения")]
        [MinLength(3, ErrorMessage = "Введите хотя бы 3 символа")]
        public string Password { get; set; }
        public bool IsAuthFailed { get; set; }
    }
}