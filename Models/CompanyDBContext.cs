using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EFCodeFirst.Models
{
	public class CompanyDBContext : DbContext
	{
        public CompanyDBContext() : base("name=MyConnectionString")
        {

        }
        // Define DbSets for each entity
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}