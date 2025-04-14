using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EFCodeFirst.FIlters;
using EFCodeFirst.Identity;

namespace EFCodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            AppDBContext db = new AppDBContext();
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AppUser model)
        {
            if (ModelState.IsValid)
            {
                AppDBContext db = new AppDBContext();
                var passwordHash = Crypto.HashPassword(model.PasswordHash);
                var user = new AppUser()
                {
                    UserName = model.UserName,
                    PasswordHash = passwordHash,
                    Email = model.Email,
                    City = model.City
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}