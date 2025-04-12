using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EFCodeFirst.Identity
{
	public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext() : base("name=MyConnectionString")
        {
        }
        public static AppDBContext Create()
        {
            return new AppDBContext();
        }

        //public System.Data.Entity.DbSet<EFCodeFirst.Identity.AppUser> AppUsers { get; set; }
    }
}