using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFKOISTSTEM.SERVICE;
using WCFKOISYSTEM.MVCWEBAPP.SERVICE;

namespace WCFKOISYSTEM.MVCWEBAPP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Service1Client client = new Service1Client();

            try
            {
                var result = client.GetTravels();
                client.Close();
                return View(result.ToList());
            }
            catch (Exception ex)
            {
                client.Abort();
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }

        public ActionResult Details(string id)
        {
            Service1Client client = new Service1Client();
            Travel travel = client.GetTravelById(id);
            client.Close();

            return View(travel);
        }

        public ActionResult Create()
        {
            return View(new Travel());
        }

        [HttpPost]
        public ActionResult Create(Travel travel)
        {
            if (ModelState.IsValid)
            {
                Service1Client client = new Service1Client();
                client.CreateOrUpdateTravel(travel);
                client.Close();
                return RedirectToAction("Index");
            }
            return View(travel);
        }

        public ActionResult Edit(string id)
        {
            Service1Client client = new Service1Client();
            Travel travel = client.GetTravelById(id);
            client.Close();
            return View(travel);
        }

        [HttpPost]
        public ActionResult Edit(Travel travel)
        {
            if (ModelState.IsValid)
            {
                Service1Client client = new Service1Client();
                client.CreateOrUpdateTravel(travel);
                client.Close();
                return RedirectToAction("Index");
            }
            return View(travel);
        }

        public ActionResult Delete(string id)
        {
            Service1Client client = new Service1Client();
            Travel travel = client.GetTravelById(id);
            client.Close();
            return View(travel);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(string id)
        {
            Service1Client client = new Service1Client();
            client.DeleteTravel(id);
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