using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebStore.WebUi.AuthenticationService;
using WebStore.WebUi.Models;

namespace WebStore.WebUi.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Index()
        {
            return View(new UserViewModel { IsAuthenticated = User.Identity.IsAuthenticated, UserName = User.Identity.Name });
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Authentication");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View(new AuthenticationParamsViewModel { });
        }

        [HttpPost]
        public ActionResult LogIn(AuthenticationParamsViewModel auth)
        {
            if (!ModelState.IsValid)
                return View(auth);
            using (var client = new AuthenticationServiceClient())
            {
                if (!client.CheckUser(auth.User, auth.Password))
                    return View(new AuthenticationParamsViewModel { IsAuthFailed = true, Password = "", User = "" });
            }

            FormsAuthentication.SetAuthCookie(auth.User, true);
            return RedirectToAction("Catalog", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new AuthenticationParamsViewModel { });
        }

        [HttpPost]
        public ActionResult Register(AuthenticationParamsViewModel auth)
        {
            if (!ModelState.IsValid)
                return View(auth);
            using (var client = new AuthenticationServiceClient())
            {
                if (!client.RegisterUser(auth.User, auth.Password))
                    throw new Exception($"Ошибка при регистрации пользователя {auth.User}.");
            }
            FormsAuthentication.SetAuthCookie(auth.User, true);
            return RedirectToAction("Catalog", "Home");
        }
    }
}