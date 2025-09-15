using ServiceLayerPractices.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ServiceLayerPractices.Controllers
{
    public class HomeController : Controller
    {
        string connection_str = ConfigurationManager.ConnectionStrings["my_connection"].ConnectionString;

        HomeService hm = new HomeService();

        //get index page
        public ActionResult Index()
        {

            return View();
        }

        ////show student data
        //public ActionResult GetSutdentDetails ()
        //{
        //    var result = hm.ShowStudentUsingDataTable();
        //    return Json(new { success = true, message = "fetched", data = result }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult DeleteData(int Id)
        //{
        //    return View();
        //}
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

        //getcountry
        public ActionResult getCountry()
        {
            return View();
        }
        //postcountry
        [HttpPost]
        public ActionResult postCountry(string countryName,int countryCode)
        {
            try
            {
                string message = "";
                using (SqlConnection sqlcon=new SqlConnection(connection_str))
                {
                    SqlCommand cmd=new SqlCommand("usp_insertCountry", sqlcon);
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@countryName",countryName);
                    cmd.Parameters.AddWithValue("@countryCode",countryCode);
                    sqlcon.Open();
                    object result= cmd.ExecuteScalar();
                    if (result!=null)
                    {
                        message = result.ToString();
                    }
                    return Json(new { success = true, message = message }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //getstate
        public ActionResult getState()
        {
            return View();
        }
        //poststate
        public ActionResult postState(string countryName,string stateName,int stateCode)
        {
            return View();
        }

    }
}