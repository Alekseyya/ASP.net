using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.WebUi.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            AdditionalInfo = new UserAdditionInformationViewModel();
        }
        public string UserName { get; set; }        
        public bool IsAuthenticated { get; set; }
        public UserAdditionInformationViewModel AdditionalInfo { get; set; }
    }
    public class UserAdditionInformationViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

    }
}