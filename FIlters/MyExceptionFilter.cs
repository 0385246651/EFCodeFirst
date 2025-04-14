using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//ghi lỗi ra file
using System.IO;

namespace EFCodeFirst.FIlters
{
	public class MyExceptionFilter: FilterAttribute , IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string message = "Message: " + filterContext.Exception.Message;
            // cấu hình đường dẫn ghi lỗi vào file trong đường dẫn
            StreamWriter stream = File.AppendText(
             filterContext.RequestContext.HttpContext.Request.PhysicalApplicationPath + "\\errorlog.txt"
             );
            stream.WriteLine(message);
            stream.Close();

            filterContext.ExceptionHandled = true; // đánh dấu là đã xử lý lỗi
            filterContext.Result = new  RedirectResult("~/Home/Error"); // chuyển hướng về trang lỗi
        }
    }
}