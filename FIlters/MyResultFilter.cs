using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.FIlters
{
	public class MyResultFilter : FilterAttribute, IResultFilter
    {
        // gọi sau khi view được return về
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // ở đây ko có tác dụng vì nó đã return về view rồi
            filterContext.Controller.ViewBag.Number = 25;
            //throw new NotImplementedException();
        }
        // gọi trước khi view săp đc return về và sau khi OnActionExecuted được thực thi 
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Number = 20;
            //throw new NotImplementedException();
        }
	}
}