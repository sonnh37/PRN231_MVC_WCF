using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFKOISYSTEM.MVCWEBAPP.SERVICE;

namespace WCFKOISYSTEM.MVCWEBAPP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Tạo một instance của Service1Client
            Service1Client client = new Service1Client();

            try
            {
                // Gọi một phương thức từ service
                var result = client.GetTravels();

                // Đóng kết nối client
                client.Close();

                // Trả về kết quả cho view
                return View(result.ToList());
            }
            catch (Exception ex)
            {
                // Handle lỗi nếu có
                client.Abort();
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}