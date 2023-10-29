using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKTXHCMUTE.DBLayer
{
    public class MY_DB
    {
        SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = QLKTXHCMUTE; Integrated Security = True");
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
        SqlConnection conAdmin = new SqlConnection(@"Data Source = localhost; Initial Catalog = QLKTXHCMUTE; Integrated Security = True");
        public SqlConnection getConnectionAdmin
        {
            get
            {
                return conAdmin;
            }
        }
        // open the connection
        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void openConnectionAdmin()
        {
            if (conAdmin.State == ConnectionState.Closed)
            {
                conAdmin.Open();
            }
        }
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void closeConnectionAdmin()
        {
            if (conAdmin.State == ConnectionState.Open)
            {
                conAdmin.Close();
            }
        }
    }
}
