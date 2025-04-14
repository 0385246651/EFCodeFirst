using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.ViewModel;
using EFCodeFirst.Models;
using EFCodeFirst.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EFCodeFirst.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            //throw new Exception("Error - Cannot register right now!");
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                // Save the user to the database
                // Redirect to a success page or login page
                var appDbContext = new AppDBContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passwordHash = Crypto.HashPassword(model.Password);
                var user = new AppUser()
                {
                    UserName = model.UserName,
                    PasswordHash = passwordHash,
                    Email = model.Email,
                    PhoneNumber = model.Mobile,
                    Birthday = model.DateOfBirth,
                    Address = model.Address,
                    City = model.City
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    this.LoginUser(userManager, user);
                }
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Please Enter Username and Password !.");
                return View();
            }
        }

        public ActionResult Login()
        {
            //throw new Exception("Error - Cannot login right now!");
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            var appDbContext = new AppDBContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(model.UserName, model.Password);
            if (user != null)
            {
                this.LoginUser(userManager, user);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new {area = "Admin"});
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid Username or Password");
                return View();
            }
        }

        //Built in Filter Quy đinh đây ko phải là action mà chỉ là method
        [NonAction]
        public void LoginUser(AppUserManager userManager, AppUser user)
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenManager.SignIn(new AuthenticationProperties(), userIdentity);
        }

        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile()
        {
            var appDbContext = new AppDBContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var userId = User.Identity.GetUserId();
            var user = userManager.FindById(userId);
            if (user != null)
            {
                var model = new RegisterVM()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Mobile = user.PhoneNumber,
                    DateOfBirth = user.Birthday ?? DateTime.Now,
                    Address = user.Address,
                    City = user.City
                };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}