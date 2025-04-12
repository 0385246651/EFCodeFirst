using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Models;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace EFCodeFirst.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();
        // GET: Products
        public ActionResult Index(string search = "", string SortColumn =
             "ProductId", string IconClass = "fa-sort-asc", int page = 1)
        {
            //List<Product> products = db.Products.ToList();
            //searching
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;

            //sorting
            if (SortColumn == "ProductID")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductID).ToList();
                }
            }
            else if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductName).ToList();
                }
            }
            else if (SortColumn == "Price")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.Price).ToList();
                }
            }
            else if (SortColumn == "DateOfPurchase")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.DateOfPurchase).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.DateOfPurchase).ToList();
                }
            }
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            //Pagination
            int NoOfRecordPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count())
                / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.NoOfPages = NoOfPages;
            ViewBag.Page = page;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(products);
        }

        //Create GET
        public ActionResult Create()
        {
            List<Category> categories = db.Categories.ToList();
            List<Brand> brands = db.Brands.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
            ViewBag.Brands = new SelectList(brands, "BrandID", "BrandName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            //ValidateModel
            if (ModelState.IsValid) {
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                //vì Custome validation không có nên cần hiển thị lại view để hiện error
                // phải bắt buốc gửi dữ liệu đi rồi và thôn tin đó gửi lên ròi . thì mới xử lý(validate) rồi hiển thị lại view
                List<Category> categories = db.Categories.ToList();
                List<Brand> brands = db.Brands.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
                ViewBag.Brands = new SelectList(brands, "BrandID", "BrandName");
                return View();
            }
        }

        public ActionResult Details(long id)
        {
            Product product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Edit(long id)
        {
            Product product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName");
            ViewBag.Brands = new SelectList(db.Brands.ToList(), "BrandID", "BrandName");
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            Product product = db.Products.Where(prod => prod.ProductID == p.ProductID).FirstOrDefault();
            product.ProductName = p.ProductName;
            product.Price = p.Price;
            product.DateOfPurchase = p.DateOfPurchase;
            product.AvailabilityStatus = p.AvailabilityStatus;
            product.CategoryID = p.CategoryID;
            product.BrandID = p.BrandID;
            product.Active = p.Active;
            //Gán product = p; = chỉ đổi tham chiếu → EF không biết để update.
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id) {
            Product product = db.Products.Where(prod => prod.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}