using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models.Cart
{
    public class CartItem
    {
        public int ProductId { get; set; }

        public int Count { get; set; }
    }
}