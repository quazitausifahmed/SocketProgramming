using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoEmployee_WebMVC.Library
{
    public class DBContext
    {
        private readonly string ConnectionString = "Data Source=DESKTOP-V4AV95B;Integrated Security=true;Initial Catalog=DemoEmployee_ZABI";

        public DataTable ExecuteQuery(string query)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            conn.Close();

            return data;
        }
    }
}