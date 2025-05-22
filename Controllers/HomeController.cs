using EFCodeFirst.FIlters;
using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace EFCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        [MyActionFilter]
        [MyResultFilter]
        public ActionResult Index()
        {
            Debug.WriteLine("Index");

            // thực hiên sau khi OnActionExecuting thực thi
            ViewBag.Number = 10;
            // đến đây thì OnActionExecuted thực thi trc khi trả về view 
            // đến đây thì OnResultExecuting thực thi trc khi trả về view
            return View();
        }

        public ActionResult About()
        {
            //throw new Exception("Error in About !!!!");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        //ignore the exception filter for this action
        //[OverrideExceptionFilters]
        public ActionResult Contact()
        {
            //throw new Exception("Error in Contact !!!!");
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Error()
        {
            ViewBag.Message = "Error page.";
            return View();
        }

        public ActionResult Temp1()
        {
            // TempData là một Dictionary (kiểu TempDataDictionary)
            // dùng để truyền dữ liệu tạm thời giữa các Action hoặc
            // giữa các Request (như từ Controller này sang View
            // hoặc từ Controller này sang Controller khác qua redirect).

            //Ví dụ thường gặp: ✅ Thông báo "Thêm sản phẩm thành công",
            //"Xóa thất bại" sau khi redirect.
            TempData["Message"] = "Helllo Friends";
            return RedirectToAction("Temp2");
        }

        public ActionResult Temp2()
        {
            // ĐỌC DỮ LIỆU TỪ TempData đánh dấu là đã đọc
            //string mess = Convert.ToString(TempData["Message"]);
            //RediretToAction thì vẫn còn tempdata chỉ đánh dấu đã đọc
            //return RedirectToAction("Temp3");

            // return view có link đến temp3
            //nếu mà bên trên đọc tempdata thì temp3 sẽ bị mất
            //vì return view ,content json

            //vẫn muốn giữ ở temp 3 dùng TempData.Kepp()
            //TempData.Keep("Message");

            //hoặc dùng TempData.Peek() 
            // vừa lấy ra dữ liệu vừa giữ lại sau return view
            string mess = Convert.ToString(TempData.Peek("Message"));

            return View();
        }

        public ActionResult Temp3()
        {
            // sẽ xóa tempdata sau khi view đc render
            string mess = Convert.ToString(TempData["Message"]);
            ViewBag.mess = mess;
            return View();
        }

        public ActionResult EditBrands()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Brand> brands = db.Brands.ToList();

            return View(brands);
        }

        [HttpPost]
        public ActionResult EditBrands(List<Brand> brands)
        {
            CompanyDBContext db = new CompanyDBContext();
            foreach (Brand brand in brands)
            {
                // tìm bản ghi có BrandID = id
                Brand brandToUpdate = db.Brands.Find(brand.BrandID);
                if (brandToUpdate != null)
                {
                    brandToUpdate.BrandName = brand.BrandName;
                }
            }
            db.SaveChanges();
            return RedirectToAction("EditBrands");
        }
    } 
}