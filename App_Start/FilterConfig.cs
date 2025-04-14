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
            // đay là filter mặc định của MVC
            filters.Add(new HandleErrorAttribute());
            // đăng kí filter của mình
            filters.Add(new MyExceptionFilter());
        }
    }
}
