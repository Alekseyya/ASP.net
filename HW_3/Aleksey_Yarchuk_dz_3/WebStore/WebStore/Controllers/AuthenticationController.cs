using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class AuthenticationController : Controller

    {
        //private static List<User> users = new List<User>
        //{
        //    new User { Login = "admin", Password = "12345" }
        //};
                
        //[HttpGet]
        //public ActionResult User()
        //{
        //    if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
        //    {
        //        var userName = Thread.CurrentPrincipal.Identity.Name;
        //        return PartialView("_User", userName);
        //    }
        //    return PartialView("_User");
        //}

        [HttpGet]
        public ActionResult Login()
        {
            return View(new AuthentificationParams { });
        }

        [HttpPost]
        public ActionResult Login(AuthentificationParams auth)
        {
            if (!ModelState.IsValid)
                return View(auth);
            if (!CheckAuthParams(auth))
            {
                auth.ErrorMessage = "Ошибка авторизации";
                return View(auth);
            }
            FormsAuthentication.SetAuthCookie(auth.Login, true);
            return Redirect(FormsAuthentication.DefaultUrl);
        }

        private bool CheckAuthParams(AuthentificationParams auth) //проверка на входящего пользователя
        {
            var user = db.users.FirstOrDefault(x => x.Login.Trim().ToLower() == auth.Login.Trim().ToLower());
            if (user != null)
                return auth.Password.Trim().ToLower() == user.Password.Trim().ToLower();
            return false;
        }
    }
}