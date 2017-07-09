using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Partonymic { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        
        public DateTime DateofBirth { get; set; }

    }
}