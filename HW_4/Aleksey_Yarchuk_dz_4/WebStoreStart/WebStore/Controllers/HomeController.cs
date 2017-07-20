using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.DAL.Context;
using WebStore.Models;
using WebStore.DAL.Repository;

namespace WebStore.Controllers
{
    
    public class HomeController : Controller
    {

        EmployeeRepository empRepo;
        PositionRepository positionRepo;
        public HomeController()
        {
            this.empRepo = new EmployeeRepository();
            this.positionRepo = new PositionRepository();
        }

       
        [MyAuthorizeAttribute(Roles = "Администратор")]
        public ActionResult Index()
        {
            var listEmployee = new List<Employee>();
            foreach (var employee in empRepo.GetList())
            {
                var empTemp = new Employee
                {
                    id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Partonymic = employee.Partonymic,
                    Age = employee.Age                    
                };
                listEmployee.Add(empTemp);
            }
            return View(listEmployee.AsEnumerable());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult List()
        {
            var listEmployee = new List<Employee>();
            foreach (var employee in empRepo.GetList())
            {
                var empTemp = new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Partonymic = employee.Partonymic,
                    Age = employee.Age
                };
                listEmployee.Add(empTemp);
            }
            return View(listEmployee.AsEnumerable());
        }

        [MyAuthorizeAttribute(Roles = "Пользователь")]
        public ActionResult Result(int id)
        {
            var employee = empRepo.GetItem(id);
            if (employee != null)
            {
                
                return View(employee);
            }
            return RedirectToAction("Index");          
        }
        public ActionResult Partial()
        {
            return PartialView();
        }

        [MyAuthorizeAttribute(Roles = "Администратор")]
        [HttpGet]
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                
                return View(new Employee());
            }

            var employeeTmp = empRepo.GetItem((int)id);
            if (employeeTmp == null)
            {
                return HttpNotFound();
            }
                        

            var employee = new Employee
            {
                id = employeeTmp.Id,
                FirstName = employeeTmp.FirstName,
                LastName = employeeTmp.LastName,
                Partonymic = employeeTmp.Partonymic,
                Age = employeeTmp.Age,
                DateofBirth = employeeTmp.DateofBirth,
                Position = empRepo.GetPosition(employeeTmp.PositionId).Name
            };

            return View(employee);
        }

        [MyAuthorizeAttribute(Roles = "Администратор")]
        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var foundPerson = empRepo.GetItem(emp.id);
               
                if (foundPerson != null)
                {
                    WebStore.Domain.Entities.Employee empTemp = new WebStore.Domain.Entities.Employee
                    {
                        Id = emp.id,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Partonymic = emp.Partonymic,
                        Age = emp.Age,
                        DateofBirth = emp.DateofBirth,
                        PositionId = empRepo.GetPositionIdForPositionName(emp.Position)

                    };

                    empRepo.Update(empTemp);
                }
                else
                {
                    WebStore.Domain.Entities.Employee empTemp = new WebStore.Domain.Entities.Employee
                    {
                        Id = emp.id,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Partonymic = emp.Partonymic,
                        Age = emp.Age,
                        DateofBirth = emp.DateofBirth,
                        PositionId = empRepo.GetPositionIdForPositionName(emp.Position)

                    };

                    empRepo.Create(empTemp);
                }

                    
               return RedirectToAction("Index");
            }

            return View(emp);
        }

        [MyAuthorizeAttribute(Roles = "Администратор")]
        public ActionResult Delete(int id)
        {
            empRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}