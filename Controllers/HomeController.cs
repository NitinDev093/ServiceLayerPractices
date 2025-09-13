using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayerPractices.DAL;

namespace ServiceLayerPractices.Controllers
{
    public class HomeController : Controller
    {
        HomeService hm = new HomeService();

        //get index page
        public ActionResult Index()
        {

            return View();
        }

        //show student data
        public ActionResult GetSutdentDetails ()
        {
            var result = hm.ShowStudentUsingDataTable();
            return Json(new { success = true, message = "fetched", data = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteData(int Id)
        {
            return View();
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