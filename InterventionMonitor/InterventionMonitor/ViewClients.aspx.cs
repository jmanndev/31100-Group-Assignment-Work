using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterventionMonitor.Models;
using System.Data.SqlClient;
using System.Configuration;
using InterventionMonitor.DataAccess;
using Microsoft.AspNet.Identity;

namespace InterventionMonitor
{
    public partial class ViewClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = DatabaseConnections.GetDataConnection();         
            string queryString = "Select * From Client";
            SqlCommand comm = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = comm.ExecuteReader();

            LbClients.DataSource = reader;
            LbClients.DataTextField = "Name";
            LbClients.DataValueField = "ID";
            LbClients.DataBind();
            
            connection.Close();
        }

        protected void BtnCreateClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateClient.aspx");
        }
    }
}