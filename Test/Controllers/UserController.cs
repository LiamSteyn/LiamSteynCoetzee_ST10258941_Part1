using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Test.Models;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        private static string con_string = "Server=tcp:cldv-liam-server.database.windows.net,1433;Initial Catalog=Cloud-Dev-Steyn;Persist Security Info=False;User ID=Liam;Password=2004Coetzee;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        private static SqlConnection con = new SqlConnection(con_string);

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult About(userTBL Users)
        {
            int result = insert_User(Users);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult About()
        {
            userTBL model = new userTBL();
            return View(model);
        }


        private int insert_User(userTBL n)
        {
            string sql = "INSERT INTO userTBL (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email); SELECT SCOPE_IDENTITY();";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Name", n.Name);
                cmd.Parameters.AddWithValue("@Surname", n.Surname);
                cmd.Parameters.AddWithValue("@Email", n.Email);
                con.Open();
                object result = cmd.ExecuteScalar();

                // Check if the result is DBNull.Value
                int usersID = result == DBNull.Value ? -1 : Convert.ToInt32(result);

                con.Close();
                return usersID;
            }

        }
    }
}
