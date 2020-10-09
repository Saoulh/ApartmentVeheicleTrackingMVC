using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class BaseRepo
    {
        public static string ConnectionString = "Data Source=DESKTOP-ONUB08E\\SQLEXPRESS;Initial Catalog=AptVehicles;Integrated Security=True";

        public static SqlConnection GetOpenConnection()
        {
            var cs = ConnectionString;
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }
    }
}
