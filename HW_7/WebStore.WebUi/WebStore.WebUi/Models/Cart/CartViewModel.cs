using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models.Cart
{
    public class CartViewModel
    {
        public Dictionary<service.ProductDataContract, int> Items { get; set; }
        public int ItemsCount
        {
            get
            {
                return Items == null ? 0 : Items.Sum(x => x.Value);
            }
        }
    }
}