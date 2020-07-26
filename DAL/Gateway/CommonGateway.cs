using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace StockManagementSystem.DAL.Gateway
{
    public class CommonGateway
    {
        public SqlConnection  Connection{ get; set; }

        public SqlCommand Command { get; set; }

        public SqlDataReader Reader { get; set; }

        public string Query { get; set; }

        string connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBConnection"].ConnectionString;

        public CommonGateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}