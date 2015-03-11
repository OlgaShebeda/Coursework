using MathСalculator.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathСalculator.WebUI.Models;
using MathСalculator.Domain.Entities;
using System.Web.Security;
using System.Drawing;
using System.IO;

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
        public ActionResult Register(UsersRegister model, HttpPostedFileBase image)
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
            if (image != null)
            {
                user.ImageMimeType = image.ContentType;
                user.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(user.ImageData, 0, image.ContentLength);
            }
            _repo.Create(user);
            if (_repo.Authentication(model.Login, model.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(user.Login, false);
                return RedirectToAction("Index","Methods");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Methods");
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult Login(UsersLogin model)
        {
            if (ModelState.IsValid && _repo.Authentication(model.Login, model.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(model.Login, false);

            }
            else
                ModelState.AddModelError("", "Incorrect login or password!");

            return View();
        }

        public ViewResult Account()
        {
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.IsLogIn = false;
                var defaultUser = new Users { Links = GetLinksOfAnonimusUsers() };
                return View(defaultUser);
            }
            ViewBag.IsLogIn = true;
            var user = _repo.Get.FirstOrDefault(u => u.Login == User.Identity.Name);
            if (user != null)
                user.Links = GetLinksOfAutorizireUsers();

            return View(user);
        }

        private static IEnumerable<Link> GetLinksOfAnonimusUsers()
        {
            return new List<Link>
            {
                new Link {Name = "Войти", Url = "/Login", NameController = "Users"},
                new Link {Name = "Регистрация", Url = "/Register", NameController = "Users"}
            };
        }

        private IEnumerable<Link> GetLinksOfAutorizireUsers()
        {
            var links = new List<Link>();
            links.Add(new Link { Name = "Change password", Url = "/ChangeUsersPassword", NameController = "Users" });
            links.Add(new Link { Name = "Log out", Url = "/Logout", NameController = "Users" });
            return links;
        }

        public FileContentResult GetImage(int userId)
        {
            Users user = _repo.Get.FirstOrDefault(p => p.Id == userId);
            if (user.ImageData != null)
                return File(user.ImageData, user.ImageMimeType);
            return null;
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}