using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteEverton.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string str = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=DBTestePratico;Integrated Security=SSPI;";
            string qs = "SELECT * FROM dbo.Loja;";
            CreateCommand(qs, str);
            return View();
        }

        private static void CreateCommand(string queryString,
            string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
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