using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {                      
            return View(db.employees);
        }
        
        public ActionResult Result(int id)
        {
            var employee = FindEmployee(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");          
        }
        public Employee FindEmployee(int id)
        {
            foreach (var employee in db.employees)
            {
                if (employee.id == id)
                {
                    return employee;
                }
            }
            return null;
        }

        [HttpGet]
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var employee = FindEmployee((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            var foundPerson = FindEmployee(emp.id);

            foundPerson.FirstName = emp.FirstName;
            foundPerson.LastName = emp.LastName;
            foundPerson.Age = emp.Age;
            
            return RedirectToAction("Index");
        }



    }
}