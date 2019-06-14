using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementWebApp.DAL
{
    public class BaseGateway
    {

        public string connectionStirng =
           WebConfigurationManager.ConnectionStrings["StockManDBConString"].ConnectionString;


        public SqlConnection Connection;
        public BaseGateway()
        {
            Connection = new SqlConnection(connectionStirng);
        }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
    }
}