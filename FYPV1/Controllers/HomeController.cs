using FYPV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPV1.Controllers
{
    public class HomeController : Controller
    {

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
        public ActionResult StudentDashBoard()
        {
            
            return View();
        }
        public ActionResult TeacherDashBoard()
        {

            return View();
        }
        [HttpGet]
        public ActionResult AdminDashBoard()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
            public ActionResult AdminDashBoard(AdminDashBoardVM obj)
        {
            //Domain
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Domain] (DomainName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.DomainName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Allied Fields
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[AlliedField] (AlliedFieldName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.AlliedFieldName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Supervisor
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Supervisor] (SupervisorName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.SupervisorName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Co-Supervisor
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Co_Supervisor] (CoSupervisorName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.CoSupervisorName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Batch
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Batch] (BatchName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.BatchName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Campus
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Campus] (CampusName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.CampusName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //program
            //string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery1 = "insert into [dbo].[Program] (ProgramName) values (@name)";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@name", obj.ProgramName);
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            //Semester
            string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery1 = "insert into [dbo].[Semester] (SemesterNumber) values (@name)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery1, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@name", obj.SemesterNumber);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            return RedirectToAction("AdminDashBoard");
        }
    }
}