using InterventionMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using InterventionMonitor.DataAccess;
using System.Data.SqlClient;

namespace InterventionMonitor
{
    public partial class ViewClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // REPLACE THIS CODE TO PULL DATA FOR INDIVIDUAL CLIENT FROM DB

            /*  SqlConnection conn = DatabaseConnections.DataConnection;
              string query = "Select//";
              SqlCommand command = new SqlCommand(query, conn);
              conn.Open();
              SqlDataReader reader = command.ExecuteReader();
              */
            if (!IsPostBack)
            {
                if (Session["ClientID"] != null)
                {
                    string clientID = Session["ClientID"].ToString();
                    using (SqlConnection connection = DatabaseConnections.GetDataConnection()) {
                        string queryString = "Select 1 From Client Where ID=" + clientID;
                        SqlCommand comm = new SqlCommand(queryString, connection);
                        connection.Open();
                        SqlDataReader reader = comm.ExecuteReader();

                        //need to make the reader hold only one row.  currently its getting ALL data from multiple rows
                        
                            txtName.Text = reader["Name"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtNotes.Text = reader["Notes"].ToString();
                        
                        reader.Close();
                    }
                }

                LbInterventions.DataSource = Monitor.Instance.Interventions;
                LbInterventions.DataTextField = "DisplayValue"; // TODO: Turn into GridView
                LbInterventions.DataBind();
            }
        }

        protected void BtnCreateIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateIntervention.aspx");
        }
    }
}