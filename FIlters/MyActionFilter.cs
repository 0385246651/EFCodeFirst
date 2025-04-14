using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace EFCodeFirst.FIlters
{
    public class MyActionFilter : FilterAttribute, IActionFilter
    {
        // gọi sau khi action được thực thi
        // chạy trc khi action đó return về view
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.Number = 15;
            //throw new NotImplementedException();
        }

        // gọi trước khi action được thực thi`
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("OnActionExecuting");
            //truyền vào viewbag vào các controllers áp dụng Filter này .
            filterContext.Controller.ViewBag.Number = 100;
            //throw new NotImplementedException();
        }
    }
}