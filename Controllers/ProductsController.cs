using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Models;
using EFCodeFirst.FIlters;

namespace EFCodeFirst.Controllers
{
    
    public class ProductsController : Controller
    {
        [MyAuthenFilter]
        [MyExceptionFilter]
        // GET: Products
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> products = db.Products.ToList();

            return View(products);
        }

        // Chỉ đc gọi thông qua view chứ ko đc gọi trực tiếp là 1 Action
        [ChildActionOnly]
        public ActionResult DisplaySingleProduct(Product p)
        {
            return PartialView("Myproduct", p);
        }
    }
}