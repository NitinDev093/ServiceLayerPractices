using ServiceLayerPractices.DAL;
using ServiceLayerPractices.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

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
        public ActionResult postState(int countryId, string stateName, int stateCode)
        {
            try
            {
                string message = "";
                using(SqlConnection sqlcon=new SqlConnection(connection_str))
                {
                    SqlCommand cmd = new SqlCommand("usp_insertState", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("countryId",countryId);
                    cmd.Parameters.AddWithValue("stateName",stateName);
                    cmd.Parameters.AddWithValue("stateCode",stateCode);
                    sqlcon.Open();
                    object result = cmd.ExecuteScalar();
                    if (result!=null)
                    {
                        message = result.ToString();
                    }
                    return Json(new {success=true,message=message }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult readCountry() 
        {
            try
            {
                List<CountryModel> countryNames = new List<CountryModel>();
                using (SqlConnection sqlcon=new SqlConnection(connection_str))
                {
                    SqlCommand cmd=new SqlCommand("usp_readCountry", sqlcon);
                    cmd.CommandType= CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader rdr= cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CountryModel cm= new CountryModel();
                        cm.countryid= Convert.ToInt32(rdr["countryId"]);
                        cm.countryname=rdr["countryName"].ToString();
                        countryNames.Add(cm);
                    }
                }
                return Json(new { success = true, message = "fetched", data = countryNames }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}