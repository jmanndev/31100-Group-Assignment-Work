using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using InterventionMonitor.DataAccess;

namespace InterventionMonitor
{
    public partial class Approvals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = User.Identity.GetUserId();
            string districtId = "";
            SqlConnection connection = DatabaseConnections.GetDataConnection();
            string query = "Select DistrictId From Manager Where Manager.EmployeeId = '" + id +"'";
            SqlCommand comm = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                districtId = reader[0].ToString();
            }
            connection.Close();

            string queryString = "Select * From Intervention INNER JOIN Client ON Client.Id = Intervention.ClientId WHERE Client.DistrictId = '" + districtId + "'";
            SqlCommand comm2 = new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader2 = comm2.ExecuteReader();
            gvApprovals.DataSource = reader2;
            gvApprovals.DataBind();

            connection.Close();
        }
    }
}