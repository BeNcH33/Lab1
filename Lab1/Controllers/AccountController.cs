using Lab1.Models;
using Lab1.Models.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<MyIdentityUser> userManager;
        private RoleManager<MyIdentityRole> roleManager;
        public AccountController()
        {
            MyIdentityDbContext db = new MyIdentityDbContext();
            UserStore<MyIdentityUser> userStore = new UserStore<MyIdentityUser>(db);
            userManager = new UserManager<MyIdentityUser>(userStore);
            RoleStore<MyIdentityRole> roleStore = new RoleStore<MyIdentityRole>(db);
            roleManager = new RoleManager<MyIdentityRole>(roleStore);
        }
        public ActionResult Register()
        {
            return View();
        }
        [Authorize (Roles="Administrator")]
        public ActionResult AdminPanel()
        {
            return View();
        }

        [Authorize(Roles = "Student, Administrator, Operator")]
        public ActionResult StudentPanel()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.BirthDate = model.BirthDate;
                user.Bio = model.Bio;
                IdentityResult result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                    return RedirectToAction("Login", "Account");
                    
                }
                else
                {
                    ModelState.AddModelError("UserName", "Ошибка при создании пользователя!");
                }
            }
            return View(model);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;

                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                    ClaimsIdentity identity = userManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = model.RememberMe;
                    authenticationManager.SignIn(props, identity);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user =
               userManager.FindByName(HttpContext.User.Identity.Name);
                IdentityResult result = userManager.ChangePassword(user.Id,
               model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    IAuthenticationManager authenticationManager =
                   HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", " Ошибка при смене пароля");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult ChangeProfile()
        {
            MyIdentityUser user = userManager.FindByName(HttpContext.User.Identity.Name);
            ChangeProfile model = new ChangeProfile();
            model.FullName = user.FullName;
            model.BirthDate = user.BirthDate;
            model.Bio = user.Bio;
            return View(model);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeProfile(ChangeProfile model)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user =
               userManager.FindByName(HttpContext.User.Identity.Name);
                user.FullName = model.FullName;
                user.BirthDate = model.BirthDate;
                user.Bio = model.Bio;
                IdentityResult result = userManager.Update(user);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Profile updated successfully.";
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при сохранении профиля.");
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}