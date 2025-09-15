using ServiceLayerPractices.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ServiceLayerPractices.DAL
{
    public class HomeService
    {
        //string connection_str = ConfigurationManager.ConnectionStrings["my_connection"].ConnectionString;

        ////public List<servicetable_model> ShowStudent()
        ////{
        ////    int sr_no = 0;
        ////    List<servicetable_model> list= new List<servicetable_model>();
        ////    using (SqlConnection sqlcon=new SqlConnection(connection_str))
        ////    {
        ////        SqlCommand cmd = new SqlCommand("showstudent", sqlcon);
        ////        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        ////        sqlcon.Open();
        ////        SqlDataReader rdr= cmd.ExecuteReader();
        ////        while (rdr.Read())
        ////        {
        ////            sr_no++;
        ////            servicetable_model stm= new servicetable_model();
        ////            stm.sr_no = sr_no;
        ////            stm.id = Convert.ToInt32(rdr["id"]);
        ////            stm.name = rdr["name"].ToString();
        ////            stm.age = Convert.ToInt32(rdr["age"]);
        ////            stm.gender = rdr["gender"].ToString();
        ////            stm.facemark = rdr["facemark"].ToString();
        ////            list.Add(stm);
        ////        }
        ////    }
        ////    //ShowStudentUsingDataTable();
        ////    return list;
        ////}

        //public List<servicetable_model> ShowStudentUsingDataTable()
        //{
        //    List<servicetable_model> items = new List<servicetable_model>();
        //    DataTable data = new DataTable();
        //    using (SqlConnection sqlcon = new SqlConnection(connection_str))
        //    {
        //        SqlCommand cmd = new SqlCommand("showstudent", sqlcon);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    //  sqlcon.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        //        sqlDataAdapter.Fill(data);
        //    }

        //        string dataTableval = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        //        items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<servicetable_model>>(dataTableval);

        //    return items;

        //}
        

    }
}