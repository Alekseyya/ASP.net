using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}