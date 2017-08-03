using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models.Order
{
    public class UserOrderDetailsViewModel
    {
        public int Id { get; set; }
        public int UserName { get; set; }
        public decimal OrderPrice { get; set; }
        public IEnumerable<UserOrderDetailsItem> Details { get; set; }
    }
}