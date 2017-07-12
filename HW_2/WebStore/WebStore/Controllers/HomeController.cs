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
            var employee = db.GetById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");          
        }
        
        [HttpGet]
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var employee = db.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var foundPerson = db.GetById(emp.id);
                if (foundPerson != null)
                    db.Edit(emp);
                else
                    db.Add(emp);
               return RedirectToAction("Index");
            }

            return View(emp);
        }

        
        public ActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}