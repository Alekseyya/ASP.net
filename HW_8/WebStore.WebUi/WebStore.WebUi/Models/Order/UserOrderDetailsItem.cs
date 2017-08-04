using System.ComponentModel.DataAnnotations;

namespace WebStore.WebUi.Models.Order
{
    public class UserOrderDetailsItem
    {
        [Display(Name="Id")]
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string ProductName { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name ="Цена за штуку")]
        public decimal TotalPrice { get; set; }

        [Display(Name ="Общая стоимость")]
        public decimal Price {
            get
            {
                return Quantity * TotalPrice;
            }
        }
    }
}