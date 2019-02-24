using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyBlog.DataAccess.Models;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager<MyUser, string> SignInManager {
            get => HttpContext.GetOwinContext().Get<SignInManager<MyUser, string>>();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result=SignInManager.PasswordSignIn(model.UserName, model.Password, true, false);
            if (result == SignInStatus.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return View(model);
            }
        }

        [Authorize]
        public ActionResult Logoff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}