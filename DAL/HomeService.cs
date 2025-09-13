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
        string connection_str = ConfigurationManager.ConnectionStrings["my_connection"].ConnectionString;

        //public List<servicetable_model> ShowStudent()
        //{
        //    int sr_no = 0;
        //    List<servicetable_model> list= new List<servicetable_model>();
        //    using (SqlConnection sqlcon=new SqlConnection(connection_str))
        //    {
        //        SqlCommand cmd = new SqlCommand("showstudent", sqlcon);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        sqlcon.Open();
        //        SqlDataReader rdr= cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            sr_no++;
        //            servicetable_model stm= new servicetable_model();
        //            stm.sr_no = sr_no;
        //            stm.id = Convert.ToInt32(rdr["id"]);
        //            stm.name = rdr["name"].ToString();
        //            stm.age = Convert.ToInt32(rdr["age"]);
        //            stm.gender = rdr["gender"].ToString();
        //            stm.facemark = rdr["facemark"].ToString();
        //            list.Add(stm);
        //        }
        //    }
        //    //ShowStudentUsingDataTable();
        //    return list;
        //}

        public List<servicetable_model> ShowStudentUsingDataTable()
        {
            List<servicetable_model> items = new List<servicetable_model>();
            DataTable data = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connection_str))
            {
                SqlCommand cmd = new SqlCommand("showstudent", sqlcon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //  sqlcon.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(data);
            }

                string dataTableval = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<servicetable_model>>(dataTableval);

            return items;



            //DataTable data = new DataTable();
            //data.Columns.Add("Id", typeof(string));
            //data.Columns.Add("Name", typeof(string));
            //data.Columns.Add("UserName", typeof(string));
            //data.Columns.Add("MobileNo", typeof(string));
            //data.Columns.Add("Email", typeof(string));

            //data.Rows.Add("123","Manish","mani","121312324","cmc.st.mamisj@gmail.com");
            //data.Rows.Add("123","Manish","mani","121312324","cmc.st.mamisj@gmail.com");
            //data.Rows.Add("123","Manish","mani","121312324","cmc.st.mamisj@gmail.com");
            //data.Rows.Add("123","Manish","mani","121312324","cmc.st.mamisj@gmail.com");
            //data.Rows.Add("123","Manish","mani","121312324","cmc.st.mamisj@gmail.com");
            //data.Rows.Add("123","Manish","mani","121312324","cmc.st.mamisj@gmail.com");
            //data.Rows.Add("123","Manish","mani","121312324","cmc.st.mamisj@gmail.com");
            //data.Rows.Add("123","Manish","mani","121312324","cmc.st.mamisj@gmail.com");


            ////foreach (DataRow row in data.Rows)
            ////{
            ////    UserData item = new UserData();//model object it is not availbale now 

            ////    item.Id = row["Id"].ToString();
            ////    item.Name = row["Name"].ToString();
            ////    item.UserName = row["UserName"].ToString();
            ////    item.MobileNo = row["MobileNo"].ToString();
            ////    item.Email = row["Email"].ToString();
            ////    items.Add(item);

            ////}

            ////for (int i = 0; i < data.Rows.Count; i++) {
            ////    UserData item = new UserData() { 
            ////    Id = data.Rows[i]["Id"].ToString(),
            ////    UserName = data.Rows[i]["UserName"].ToString()
            ////    };
            ////    items.Add(item);
            ////}




            //string dataTableval = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            //// Save JSON into a file
            ////string filePath = @"E:/MVC Basic/ServiceLayerPractices/Content/datable.json";
            ////File.WriteAllText(filePath, dataTableval);


            ////// Read JSON file into a string
            ////string jsonData = File.ReadAllText(filePath);

            //items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserData>>(dataTableval);




            //string userName = data.Rows[2]["UserName"].ToString();




            //data.AcceptChanges();

            //return data;



            DataSet dataSet = new DataSet("CompanyData");

            // ================= TABLE 1 : EmployeeData =================
            DataTable employeeTable = new DataTable("employeeTable");
            employeeTable.Columns.Add("Id", typeof(int));
            employeeTable.Columns.Add("Name", typeof(string));
            employeeTable.Columns.Add("DepartmentId", typeof(int));
            employeeTable.Columns.Add("Age",typeof(int));

            employeeTable.Rows.Add(1, "Nitin", 101,22);
            employeeTable.Rows.Add(2, "Sahani", 102,23);

            // ================= TABLE 2 : DepartmentData =================
            DataTable departmentTable = new DataTable("departmentTable");
            departmentTable.Columns.Add("DeptId", typeof(int));
            departmentTable.Columns.Add("DeptName", typeof(string));

            departmentTable.Rows.Add(101, "HR");
            departmentTable.Rows.Add(102, "IT");

            // ================= TABLE 3 : ProjectData =================
            DataTable projectTable = new DataTable("projectTable");
            projectTable.Columns.Add("ProjectId", typeof(int));
            projectTable.Columns.Add("ProjectName", typeof(string));
            projectTable.Columns.Add("EmployeeId", typeof(int));

            projectTable.Rows.Add(1001, "Payroll System", 1);
            projectTable.Rows.Add(1002, "E-Commerce App", 2);

            // ================= Add all tables into DataSet =================
            dataSet.Tables.Add(employeeTable);
            dataSet.Tables.Add(departmentTable);
            dataSet.Tables.Add(projectTable);

            if (dataSet.Tables.Count > 0)
            {
                DataTable dt = dataSet.Tables[1];
            }

            // Print example output
            Console.WriteLine("DataSet contains " + dataSet.Tables.Count + " tables.");

        }


    }
}