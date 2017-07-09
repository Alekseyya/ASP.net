using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
  static class db
    {
        public static List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    id=1,
                    FirstName = "Алексей",
                    LastName = "Генычув",
                    Partonymic = "Григорьев",
                    Age = 23,
                    Position = "Генерал иракской разведки",
                    DateofBirth = new DateTime(2000, 3, 15)

                },
                new Employee
                {
                    id = 2,
                    FirstName = "Афанасий",
                    LastName = "Батькович",
                    Partonymic = "Алексеев",
                    Age = 28,
                    Position = "Старший прапорщик",
                    DateofBirth = new DateTime(1998, 4, 15)
                },
                new Employee
                {
                    id = 3,
                    FirstName = "Мария",
                    LastName = "Конь",
                    Partonymic = "Беловна",
                    Age = 27,
                    Position = "Повар",
                    DateofBirth = new DateTime(1665, 9, 18)
                }
            };
    }
}