using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class Employee
    {
        public int id { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Неправильно введено имя")]
        [Display(Name ="Имя")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Имя должно состоять от 3 до 20 символов")]
        [RegularExpression(@"[А-Я][а-я]{3,20}", ErrorMessage = "Несоответствует паттерну")]        
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Неправильно введена фамилия")]
        [Display(Name = "Фамилия")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Фамилия должно состоять от 5 до 25 символов")]        
        public string LastName { get; set; }

        [StringLength(25, MinimumLength = 5, ErrorMessage = "Отчество должно состоять от 5 до 25 символов")]
        [Display(Name = "Отчество")]
        public string Partonymic { get; set; }
        
        [Range(18, 65)]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [StringLength(50,MinimumLength = 3, ErrorMessage = "Возраст должно состоять от 1 до 2 символов")]
        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата рождения является обязательной")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MM/yyyy", ConvertEmptyStringToNull = true)]
        [Display(Name="Дата рождения")]
        public DateTime DateofBirth { get; set; }

    }
}