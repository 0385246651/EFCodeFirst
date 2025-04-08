using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Models;

namespace EFCodeFirst.Controllers
{
    public class BrandsController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();
        // GET: Brand
        public ActionResult Index()
        {
            // Create an instance of the database context
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }


        //Create GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Brand b)
        {
            db.Brands.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            Brand brand = db.Brands.Find(id);
            return View(brand);
        }

        public ActionResult Edit(long id)
        {
            Brand brand = db.Brands.Find(id);
            return View(brand);
        }

        [HttpPost]
        public ActionResult Edit(Brand b)
        {
            Brand brand = db.Brands.Find(b.BrandID);
            brand.BrandName = b.BrandName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            Brand brand =  db.Brands.FirstOrDefault(b => b.BrandID == id);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}