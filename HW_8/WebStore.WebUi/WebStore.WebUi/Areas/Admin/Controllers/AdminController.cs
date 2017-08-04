using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUi.Areas.Admin.Models;
using WebStore.WebUi.AuthenticationService;

namespace WebStore.WebUi.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            using (var admin = new AuthenticationServiceClient())
            {
                var isAdmin = admin.UserInGroup(User.Identity.Name, "Administrator");
                if (isAdmin)
                    return View();
            }
            return RedirectToAction("Catalog", "Home");
        }

        public ActionResult Users()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            using (var admin = new AuthenticationServiceClient())
            {
                foreach (var item in admin.GetUsers())
                {
                    var tt = item.Group;
                    users.Add(new UserViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Group = item.Group,
                        Password = item.Password,
                        IsDeleted = item.IsDeleted
                    });
                }                
            }
            return View(users.AsEnumerable());
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            using (var admin = new AuthenticationServiceClient())
            {
                admin.DeleteUser(id);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            UserViewModel userEdit = new UserViewModel();
            using (var admin = new AuthenticationServiceClient())
            {
               var user = admin.GetUserById(id);
                userEdit.Id = user.Id;
                userEdit.Name = user.Name;
                userEdit.Password = user.Password;
                userEdit.IsDeleted = user.IsDeleted;
                userEdit.Group = user.Group;
            }
            return View(userEdit);
        }
        [HttpPost]
        public ActionResult EditUser(UserViewModel user)
        {
            using (var admin = new AuthenticationServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<UserViewModel, AuthenticationService.UserDataContract>());
                var userEdit = Mapper.Map<UserViewModel, AuthenticationService.UserDataContract> (user);
                admin.EditUser(userEdit);
            }
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Groups()
        {
            IEnumerable<GroupViewModel> groups = new List<GroupViewModel>();
            using (var admin = new AuthenticationServiceClient())
            {
                Mapper.Initialize(o => o.CreateMap<AuthenticationService.GroupDataContract, GroupViewModel>());
                groups = Mapper.Map<IEnumerable<AuthenticationService.GroupDataContract>, IEnumerable<GroupViewModel>>(admin.GetGroups());
                
            }
            return View(groups);
        }

        [HttpGet]
        public ActionResult DeleteGroup(int id)
        {
            using (var admin = new AuthenticationServiceClient())
            {
                admin.DeleteGroup(id);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult RestoreGroup(int id)
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult AddGroup()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult EditGroup(int id)
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult EditGroup(GroupViewModel group)
        {
            return View();
        }

    }
}