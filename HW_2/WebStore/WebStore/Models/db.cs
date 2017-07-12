﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 2.	Весь функционал приложения должен быть рабочим в текущем приложении,
/// но данные будут браться из статического хранилища.
//3.	Необходимо обеспечить возможность создания новых пользователей 
//при помощи формы для создания новых пользователей.
//4.	Необходимо обеспечить возможность редактирования,
//удаления и сохранения изменений для пользователей в списке при помощи созданной формы.
//
/// </summary>

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
                    DateofBirth = DateTime.Now.AddYears(-26)

                },
                new Employee
                {
                    id = 2,
                    FirstName = "Афанасий",
                    LastName = "Батькович",
                    Partonymic = "Алексеев",
                    Age = 28,
                    Position = "Старший прапорщик",
                    DateofBirth = DateTime.Now.AddYears(-29)
                },
                new Employee
                {
                    id = 3,
                    FirstName = "Мария",
                    LastName = "Конь",
                    Partonymic = "Беловна",
                    Age = 27,
                    Position = "Повар",
                    DateofBirth = DateTime.Now.AddYears(-69)
                }
            };

        //Возвращение по id
        public static Employee GetById(int id)
        {
            foreach (var employee in employees)
            {
                if (employee.id == id)
                {
                    return employee;
                }
            }
            return null;
        }

        //Удаление по id
        public static void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }

        //Добавление 
        public static void Add(Employee emp)
        {
            emp.id = employees.Max(i => i.id) + 1;            
            employees.Add(emp);
        }

        //Изменение
        public static void Edit(Employee emp)
        {
            var employee = GetById(emp.id);

            if (employee.FirstName != emp.FirstName)
                employee.FirstName = emp.FirstName;

            if (employee.LastName != emp.LastName)
                employee.LastName = emp.LastName;

            if (employee.Partonymic != emp.Partonymic)
                employee.Partonymic = emp.Partonymic;

            if (employee.Age != emp.Age)
                employee.Age = emp.Age;

            if (employee.DateofBirth != emp.DateofBirth)
                employee.DateofBirth = emp.DateofBirth;
            
            if (employee.Position != emp.Position)
                employee.Position = emp.Position;

        }
    }
}