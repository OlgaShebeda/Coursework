using MathСalculator.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathСalculator.WebUI.Models;
using MathСalculator.Domain.Entities;
using System.Web.Security;

namespace MathСalculator.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository _repo;

        public UsersController(IUserRepository repoParam)
        {
            _repo = repoParam;
        }
        //
        // GET: /Users/
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Register(UsersRegister model)
        {
            if (!ModelState.IsValid || _repo.CheckExist(model.Login))
            {
                ModelState.AddModelError("", "User with name already exists");
                return View(model);
            }
            var user = new Users()
            {
                Login = model.Login,
                Password = model.Password.GetHashCode().ToString(),
                Email = model.Email,
            };
            _repo.Create(user);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult Login(UsersLogin model)
        {
            if (ModelState.IsValid && _repo.Authentication(model.Login, model.Password))
                FormsAuthentication.RedirectFromLoginPage(model.Login, false);
            else
                ModelState.AddModelError("", "Incorrect login or password!");

            return View();
        }

        public ViewResult Account()
        {
            if (!User.Identity.IsAuthenticated)
            {
                var defaultUser = new Users { Links = GetLinksOfAnonimusUsers() };
                return View(defaultUser);
            }

            var user = _repo.Get.FirstOrDefault(u => u.Login == User.Identity.Name);
            if (user != null)
                user.Links = GetLinksOfAutorizireUsers();

            return View(user);
        }

        private static IEnumerable<Link> GetLinksOfAnonimusUsers()
        {
            return new List<Link>
            {
                new Link {Name = "Log in", Url = "/Login", NameController = "Users"},
                new Link {Name = "Sign up", Url = "/Register", NameController = "Users"}
            };
        }

        private IEnumerable<Link> GetLinksOfAutorizireUsers()
        {
            var links = new List<Link>();
            //if (User.IsInRole("administrator"))
            //    links.Add(new Link { Name = "Users", Url = "/AllUsersShow", NameController = "Admin" });

            //if (!User.IsInRole("fan"))
            //{
            //    links.Add(new Link { Name = "Edit posts", Url = "/Index", NameController = "ChangePost" });
            //    links.Add(new Link { Name = "Create post", Url = "/CreatePost", NameController = "ChangePost" });
            //}

            links.Add(new Link { Name = "Change password", Url = "/ChangeUsersPassword", NameController = "Users" });
            links.Add(new Link { Name = "Log out", Url = "/Logout", NameController = "Users" });
            return links;
        }
	}
}