using InterventionMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionMonitor
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = DatabaseConnections.GetDataConnection();
                string queryString = "Select * From Employee";
                SqlCommand comm = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = comm.ExecuteReader();
                lbUsers.DataSource = reader;
                lbUsers.DataTextField = "Name";
                lbUsers.DataValueField = "Id";
                lbUsers.DataBind();

                connection.Close();
            }
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            SqlConnection connection = DatabaseConnections.GetDataConnection();
            string queryString = "Select * From Employee";
            SqlCommand comm = new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = comm.ExecuteReader();
            lbUsers.DataSource = reader;
            lbUsers.DataTextField = "Name";
            lbUsers.DataValueField = "Id";
            lbUsers.DataBind();

            connection.Close();
        }

        protected void btnEngineer_Click(object sender, EventArgs e)
        {
            SqlConnection connection = DatabaseConnections.GetDataConnection();
            string queryString = "SELECT * FROM Employee INNER JOIN SiteEngineer ON Employee.Id = SiteEngineer.EmployeeId";
            SqlCommand comm = new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = comm.ExecuteReader();
            lbUsers.DataSource = reader;
            lbUsers.DataTextField = "Name";
            lbUsers.DataValueField = "Id";
            lbUsers.DataBind();

            connection.Close();
        }

        protected void btnManager_Click(object sender, EventArgs e)
        {
            SqlConnection connection = DatabaseConnections.GetDataConnection();
            string queryString = "SELECT * FROM Employee INNER JOIN Manager ON Employee.Id = Manager.EmployeeId";
            SqlCommand comm = new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = comm.ExecuteReader();
            lbUsers.DataSource = reader;
            lbUsers.DataTextField = "Name";
            lbUsers.DataValueField = "Id";
            lbUsers.DataBind();

            connection.Close();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            
            string s = lbUsers.SelectedItem.Value;
            Session["EmployeeID"] = lbUsers.SelectedItem.Value;
            Response.Redirect("EditEmployee.aspx");
        }
    }
}