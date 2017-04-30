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

namespace InterventionMonitor
{
    public partial class ViewClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlConnection connection = DatabaseConnections.DataConnection;         
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

        protected void BtnViewClient_Click(object sender, EventArgs e)
        {
            var x = LbClients.SelectedValue;
            Response.Redirect("ViewClient.aspx");
        }

        protected void BtnCreateClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateClient.aspx");
        }

        protected void LbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = "";
            x = LbClients.SelectedItem.Value;
        }
    }
}