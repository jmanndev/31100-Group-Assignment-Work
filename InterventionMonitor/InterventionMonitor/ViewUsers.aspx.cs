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
    // Populates controls with relevant query items - note:meant to take out all bd calls but ran out of time
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

        //populates the list box with all employees
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

        //populates the listbox with all employees of type site engineer
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

        //populates the listbox with all employees of type manager
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
            //stashes the selected employee ID into a session item
            string s = lbUsers.SelectedItem.Value;
            Session["EmployeeID"] = lbUsers.SelectedItem.Value;
            Response.Redirect("EditEmployee.aspx");
        }
    }
}