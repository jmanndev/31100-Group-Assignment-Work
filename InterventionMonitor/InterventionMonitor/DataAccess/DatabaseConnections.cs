using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace InterventionMonitor.DataAccess
{
    public class DatabaseConnections
    {
           public static SqlConnection DataConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ToString());
    }
}