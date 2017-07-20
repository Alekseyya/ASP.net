using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.DAL.Repository;

namespace WebStore.Models
{
    public class Employee
    {
        PositionRepository positionRepo;
        public Employee()
        {
            this.positionRepo = new PositionRepository();
        }
        public int id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Неправильно введено имя")]
        [Display(Name = "Имя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя должно состоять от 3 до 20 символов")]
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

        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Должность должна состоять от 1 до 2 символов")]
        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата рождения является обязательной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        [Display(Name = "Дата рождения")]
        public DateTime DateofBirth { get; set; }


        public IEnumerable<SelectListItem> PositionList
        {
            get
            {
                List<SelectListItem> tmpList = new List<SelectListItem>();
                foreach (var item in positionRepo.GetList())
                {
                    tmpList.Add(new SelectListItem { Text = item.Name, Value = item.Name });
                }
                return tmpList.Select(l => new SelectListItem { Selected = (l.Value==Position), Text = l.Text, Value = l.Value });
            }
                       
        }
         
    }
}