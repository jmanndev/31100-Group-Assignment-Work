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
    public partial class ViewReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> reports = new List<string>();
                reports.Add("Please select report to view");
                reports.Add("Total cost by engineer");
                reports.Add("Average cost by engineer");
                reports.Add("Cost by district");
                reports.Add("Monthly costs for district");
                ddlReports.DataSource = reports;
                ddlReports.DataBind();

                SqlConnection connection = DatabaseConnections.DataConnection;

                string queryString = "SELECT * FROM District";
                SqlCommand comm = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = comm.ExecuteReader();

                ddlDistrict.DataSource = reader;
                ddlDistrict.DataTextField = "Name";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                connection.Close();

                string queryString2 = "SELECT * FROM Employee INNER JOIN SiteEngineer ON Employee.Id = SiteEngineer.EmployeeId";
                SqlCommand comm2 = new SqlCommand(queryString2, connection);
                connection.Open();
                SqlDataReader reader2 = comm2.ExecuteReader();
            
                ddlEngineer.DataSource = reader2;
                ddlEngineer.DataTextField = "Name";
                ddlEngineer.DataValueField = "Id";
                ddlEngineer.DataBind();
                connection.Close();
            
                ddlEngineer.Visible = false;
                ddlDistrict.Visible = false;
                lblDistrict.Visible = false;
                lblEngineer.Visible = false;
            }
        }

        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            string engineerID = ddlEngineer.SelectedItem.Value;
            string districtID = ddlDistrict.SelectedItem.Value;
            Reports report = new Reports();

            if (ddlReports.SelectedItem.ToString().Equals("Total cost by engineer"))
            {    
                decimal result = Decimal.Parse(report.TotalEngineerCost(engineerID));
                lblResultView.Text = Math.Round(result, 2).ToString();
            }
            else if(ddlReports.SelectedItem.ToString().Equals("Average cost by engineer"))
            {
                decimal result = Decimal.Parse(report.AverageEngineerCost(engineerID));
                lblResultView.Text = Math.Round(result, 2).ToString();
            }
            else if(ddlReports.SelectedItem.ToString().Equals("Cost by district"))
            {
                decimal result = Decimal.Parse(report.TotalDistrictCost(districtID));
                lblResultView.Text = Math.Round(result, 2).ToString();
            }
            else if(ddlReports.SelectedItem.ToString().Equals("Monthly costs for district"))
            {

            }
        }

        protected void ddlReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReports.SelectedItem.ToString().Equals("Total cost by engineer") | ddlReports.SelectedItem.ToString().Equals("Average cost by engineer"))
            {
                ddlEngineer.Visible = true;
                lblDistrict.Visible = false;
                lblEngineer.Visible = true;
                ddlDistrict.Visible = false;
            }
            else if (ddlReports.SelectedItem.ToString().Equals("Cost by district") | ddlReports.SelectedItem.ToString().Equals("Monthly costs for district"))
            {
                ddlEngineer.Visible = false;
                lblDistrict.Visible = true;
                lblEngineer.Visible = false;
                ddlDistrict.Visible = true;
            }
            else
            {
                ddlEngineer.Visible = false;
                lblDistrict.Visible = false;
                lblEngineer.Visible = false;
                ddlDistrict.Visible = false;
            }
        }
    }
}