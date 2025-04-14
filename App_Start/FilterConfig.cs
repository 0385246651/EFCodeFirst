using System;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.FIlters;

namespace EFCodeFirst
{
    // Nơi đăng kí filter cho toàn bộ ứng dụng
    public class FilterConfig
    {
        // Đăng kí filter cho toàn bộ ứng dụng
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // đay là filter mặc định của MVC handle lỗi
            // chỉ hoạt động khi mà Web.config có <customErrors mode="On" />
            filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(Exception), View="Error"});
            // đăng kí filter của mình
            // nếu dùng filter này thì ko cần dùng filter mặc định của MVC
            //filters.Add(new MyExceptionFilter());
        }
    }
}
