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
            #region George's version
            
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
            
            #endregion
            #region Jono's version
            /**
            if (!IsPostBack)
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
            **/
            #endregion
        }

        protected void BtnViewClient_Click(object sender, EventArgs e)
        {
            #region George's version
            var x = LbClients.SelectedValue;
            Response.Redirect("ViewClient.aspx");
            #endregion
            
            #region Jono's version
            /**
            if (LbClients.SelectedItem != null)
            {
                Session["ClientID"] = LbClients.SelectedItem.Value;
                Response.Redirect("ViewClient.aspx");
            }
            **/
            #endregion
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