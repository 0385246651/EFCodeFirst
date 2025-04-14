using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.FIlters;
using EFCodeFirst.Models;

namespace EFCodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        // Create an instance of the database context
        CompanyDBContext db = new CompanyDBContext();
        // GET: Categories
        public ActionResult Index()
        {
            // Retrieve the list of categories from the database
            List<Category> categories = db.Categories.ToList();

            return View(categories);
        }

        //Create GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            // Add the new category to the database
            db.Categories.Add(category);
            // Save changes to the database
            db.SaveChanges();
            // Redirect to the Index action
            return RedirectToAction("Index");
        }

        //Edit GET
        public ActionResult Edit(long id)
        {
            // Create an instance of the database context
            // Retrieve the category to edit
            Category category = db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            // Update the category in the database
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            // Save changes to the database
            db.SaveChanges();
            // Redirect to the Index action
            return RedirectToAction("Index");
        }

        //Detail GET
        public ActionResult Details(long id)
        {
            // Retrieve the category details
            Category category = db.Categories.Find(id);
            return View(category);
        }

        //Delete 
        public ActionResult Delete(long id)
        {
            Category category = db.Categories.Find(id);
            // Check if the category exists
            if (category == null)
            {
                return HttpNotFound();
            }
            // Remove the category from the database
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}