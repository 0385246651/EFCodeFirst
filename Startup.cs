using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using EFCodeFirst.Identity;
using System.Collections.Generic;

//khi chạy project sẽ chạy file này 
[assembly: OwinStartup(typeof(EFCodeFirst.Startup))]

namespace EFCodeFirst
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //cơ chế xác thực cookie nếu chưa login thì chueyern về login page
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            this.CreateRolesAddUsers();
        }

        public void CreateRolesAddUsers()
        {
            //QUản lý các role
            var roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(new AppDBContext()));
            var appDbContext = new AppDBContext();
            var appUserStore = new AppUserStore(appDbContext);
            //Dùng để tạo và quản lý người dùng với database đang dùng(EF Code First)
            var userManager = new AppUserManager(appUserStore);

            //tạo role admin nếu chưa tồn tại
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (userManager.FindByName("admin") ==null)
            {
                var user = new AppUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPWD = "Admin@123";

                var chkUser = userManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }

            }

            //manage users
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            if (userManager.FindByName("manager") == null)
            {
                var user = new AppUser();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                string userPWD = "manager@123";

                var chkUser = userManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }

            }

            //role user but not create user
            //manage users
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
