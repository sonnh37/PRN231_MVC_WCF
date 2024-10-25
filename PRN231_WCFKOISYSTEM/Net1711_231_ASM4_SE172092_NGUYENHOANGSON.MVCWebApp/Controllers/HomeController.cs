using Net1711_231_ASM4_SE172092_NGUYENHOANGSON.MVCWebApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Net1711_231_ASM4_SE172092_NGUYENHOANGSON.MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Service1Client client = new Service1Client();

            try
            {
                var result = client.GetBookingRequests();
                client.Close();
                return View(result.ToList());
            }
            catch (Exception ex)
            {
                client.Abort();
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }

        public ActionResult Edit(Guid id)
        {
            var client = new Service1Client();
            try
            {
                var bookingRequest = client.GetBookingRequestById(id);
                ViewBag.Customers = new SelectList(client.GetCustomers(), "Id", "Username", bookingRequest.CustomerId);
                ViewBag.Travels = new SelectList(client.GetTravels(), "Id", "Name", bookingRequest.TravelId);
                ViewBag.Status = Enum.GetValues(typeof(BookingStatus))
        .Cast<BookingStatus>()
        .Select(e => new SelectListItem
        {
            Value = e.ToString(),
            Text = e.ToString()
        });
                bookingRequest.UpdatedDate = DateTime.Now;
                return View(bookingRequest);
            }
            catch (Exception ex)
            {
                client.Abort();
                return View("Error", new HandleErrorInfo(ex, "BookingRequest", "Edit"));
            }
            finally
            {
                client.Close();
            }
        }

        public ActionResult Details(Guid id)
        {
            var client = new Service1Client();
            try
            {
                var bookingRequest = client.GetBookingRequestById(id);
                return View(bookingRequest);
            }
            catch (Exception ex)
            {
                client.Abort();
                return View("Error", new HandleErrorInfo(ex, "BookingRequest", "Edit"));
            }
            finally
            {
                client.Close();
            }
        }

        public ActionResult Create()
        {
            var client = new Service1Client();
            try
            {
                ViewBag.Customers = new SelectList(client.GetCustomers(), "Id", "Username");
                ViewBag.Travels = new SelectList(client.GetTravels(), "Id", "Name");
                ViewBag.Status = Enum.GetValues(typeof(BookingStatus))
          .Cast<BookingStatus>()
          .Select(e => new SelectListItem
          {
              Value = e.ToString(), // Lấy tên của enum làm giá trị
              Text = e.ToString() // Lấy tên của enum làm văn bản hiển thị
          });
                var bookingRequest = new BookingRequest();
                bookingRequest.CreatedDate = DateTime.Now;
                bookingRequest.UpdatedDate = DateTime.Now;
                return View(bookingRequest);
            }
            catch (Exception ex)
            {
                client.Abort();
                return View("Error", new HandleErrorInfo(ex, "BookingRequest", "Edit"));
            }
            finally
            {
                client.Close();
            }
        }

        [HttpPost]
        public ActionResult Create(BookingRequest bookingRequest)
        {
            if (ModelState.IsValid)
            {
                Service1Client client = new Service1Client();
                client.CreateOrUpdateBookingRequest(bookingRequest);
                client.Close();
                return RedirectToAction("Index");
            }
            return View(bookingRequest);
        }

        [HttpPost]
        public ActionResult Edit(BookingRequest bookingRequest)
        {
            if (ModelState.IsValid)
            {
                Service1Client client = new Service1Client();
                client.CreateOrUpdateBookingRequest(bookingRequest);
                client.Close();
                return RedirectToAction("Index");
            }
            return View(bookingRequest);
        }

        public ActionResult Delete(Guid id)
        {
            Service1Client client = new Service1Client();
            BookingRequest bookingRequest = client.GetBookingRequestById(id);
            client.Close();
            return View(bookingRequest);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Service1Client client = new Service1Client();
            client.DeleteBookingRequest(id);
            client.Close();
            return RedirectToAction("Index");
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