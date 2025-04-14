using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Models;
using EFCodeFirst.FIlters;

namespace EFCodeFirst.Controllers
{
    [MyAuthenFilter]
    //[MyExceptionFilter]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> products = db.Products.ToList();

            return View(products);
        }
    }
}