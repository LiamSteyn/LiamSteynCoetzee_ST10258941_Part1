using System;
using System.Data.SqlClient;

namespace Test.Models
{
    public class userTBL
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }

        public int insert_User()
        {
            string con_string = "Server=tcp:cldv-liam-server.database.windows.net,1433;Initial Catalog=Cloud-Dev-Steyn;Persist Security Info=False;User ID=Liam;Password=2004Coetzee;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    string sql = "INSERT INTO userTBL (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Surname", Surname);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or throw it further
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1; // Or throw an exception
            }
        }
    }
}
