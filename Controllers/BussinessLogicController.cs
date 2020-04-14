using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudUsingAspMVCJquery.Controllers
{
    public class BussinessLogicController : Controller
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        // GET: BussinessLogic
        public ActionResult Index()
        {
            return View();
        }

        public static DataSet GetSetRecord(string query)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            return dataset;
        }

        public static DataTable GetRecord(string query)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            return datatable;
        }
    }
}