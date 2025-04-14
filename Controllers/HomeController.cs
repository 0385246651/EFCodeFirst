﻿using EFCodeFirst.FIlters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            throw new Exception("Error in About !!!!");

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
    }
}