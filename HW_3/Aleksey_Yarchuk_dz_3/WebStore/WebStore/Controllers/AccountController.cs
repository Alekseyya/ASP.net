using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            var employee = db.GetEmployeeByLogin(User.Identity.Name);
            var userLogin = db.users.Find(login => login.Login == User.Identity.Name).Role;
            var model = new AccountView
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Partonymic = employee.Partonymic,
                Role = userLogin
            };
            ViewBag.AddInfo = new AdditionalInformation();
            return View(model);
        }

        [HttpGet]
        public ActionResult AdditionalInformation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel { });
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                if (!CheckAuthParams(lvm))
                {
                    lvm.ErrorMessage = "Ошибка авторизации";
                    return View(lvm);
                }
                FormsAuthentication.SetAuthCookie(lvm.Login, true);
                if (lvm.Login == "admin")
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("List", "Home");
            }  
                 
            return View(lvm);
        }

        private bool CheckAuthParams(LoginViewModel auth) //проверка на входящего пользователя
        {
            var user = db.users.FirstOrDefault(x => x.Login.Trim().ToLower() == auth.Login.Trim().ToLower());
            if (user != null)
                return auth.Password.Trim().ToLower() == user.Password.Trim().ToLower();
            return false;
        }



        [HttpPost]
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/Home/List");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var modelEmployee = new Employee
                {
                    FirstName = rvm.FirsName,
                    LastName = rvm.LastName,
                    Partonymic = rvm.Partonymic
                };
                var modelUser = new User
                {
                    Login = rvm.Login,
                    Password = rvm.Password
                };

                db.Add(modelEmployee);
                db.AddUsers(modelUser);

                FormsAuthentication.SetAuthCookie(rvm.Login, true);

                return Redirect("/Home/List");
            }
            return View(rvm);            
        }
    }
}