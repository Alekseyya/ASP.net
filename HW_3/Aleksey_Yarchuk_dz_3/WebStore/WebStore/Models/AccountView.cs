using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class AccountView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Partonymic { get; set; }
        public string Role { get; set; }
    }
    public class RegisterViewModel
    {
        [Display(Name = "Имя")]
        [StringLength(15, ErrorMessage = "Имя не должна привышать 15 символов")]
        public string FirsName { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(25, ErrorMessage = "Фамилия не должна привышать 25 символов")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(25, ErrorMessage = "Отвество не должна привышать 25 символов")]
        public string Partonymic { get; set; }

        [Display(Name = "Логин")]
        [RegularExpression(@"[a-z]{2,10}", ErrorMessage = "Логин должен состоять из матленьких букв латинского алфавита до 10 символов")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [StringLength(25, ErrorMessage = "Ограничение в 25 символов")]
        [RegularExpression(@"[a-z,1-9]{2,25}", ErrorMessage = "Пароль должен состоять из букв и цифр")]
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(1, ErrorMessage = "Длина логина должна быть не менее 1.")]
        [RegularExpression(@"[a-z,1-9]{2,15}", ErrorMessage = "Логин должен состоять их букв латинского алфавита")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(1, ErrorMessage = "Длина пароля должна быть не менее 1.")]
        [Display(Name ="Пароль")]
        [RegularExpression(@"[a-z,1-9]{2,25}", ErrorMessage = "Пароль должен состоять из букв и цифр до 25")]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

    }

}