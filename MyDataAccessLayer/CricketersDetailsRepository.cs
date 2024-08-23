using System;
using System.Data.SqlClient;

namespace MyDataAccessLayer
{
    public class CricketersDetailsRepository
    {
        string connectionString = "server=DESKTOP-BLBGEHJ\\SQLEXPRESS;database=Cricketerlist;user Id=sa;password=Anaiyaan@123;";
        SqlConnection con = null;

        public CricketersDetailsRepository()
        {
            con = new SqlConnection(connectionString);
        }
      

        
    }
}
