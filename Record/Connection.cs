using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record
{
    public class Connection
    {
        private readonly string Server = "DESKTOP-VKK3TEO\\SQLEXPRESS";
        private readonly string Database = "record";
        private string ConnectionString;
        private SqlConnection con;
        public Connection()
        {
            this.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=true",
                this.Server, this.Database);
            con = new SqlConnection(this.ConnectionString);
        }

        public SqlDataReader sendQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void openConnection()
        {
            con.Open();
        }

        public void closeConnection()
        {
            con.Close();
        }
    }
}
