using InterventionMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterventionMonitor.Models;

namespace InterventionMonitor
{
    public partial class ViewReports : System.Web.UI.Page
    {
        //was meant to move all db calls out of UI but ran out of time.
        protected void Page_Load(object sender, EventArgs e)
        {
            //populates all drop down lists however hides lists that aren't required until selection
            if (!IsPostBack)
            {
                //populates drop down list containing the report type
                List<string> reports = new List<string>();
                reports.Add("Please select report to view");
                reports.Add("Total cost by engineer");
                reports.Add("Average cost by engineer");
                reports.Add("Cost by district");
                reports.Add("Monthly costs for district");
                ddlReports.DataSource = reports;
                ddlReports.DataBind();

                SqlConnection connection = DatabaseConnections.GetDataConnection();

                //queries a list of districts and populates drop down list
                string queryString = "SELECT * FROM District";
                SqlCommand comm = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = comm.ExecuteReader();

                ddlDistrict.DataSource = reader;
                ddlDistrict.DataTextField = "Name";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                connection.Close();

                //queries a list of site engineers and populates drop down list
                string queryString2 = "SELECT * FROM Employee INNER JOIN SiteEngineer ON Employee.Id = SiteEngineer.EmployeeId";
                SqlCommand comm2 = new SqlCommand(queryString2, connection);
                connection.Open();
                SqlDataReader reader2 = comm2.ExecuteReader();
            
                ddlEngineer.DataSource = reader2;
                ddlEngineer.DataTextField = "Name";
                ddlEngineer.DataValueField = "Id";
                ddlEngineer.DataBind();
                connection.Close();
            
                //hides controls thats are not currently needed
                ddlEngineer.Visible = false;
                ddlDistrict.Visible = false;
                lblDistrict.Visible = false;
                lblEngineer.Visible = false;
            }
        }

        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            //grabs the selected index of engineer and district
            string engineerID = ddlEngineer.SelectedItem.Value;
            string districtID = ddlDistrict.SelectedItem.Value;
            Reports report = new Reports();
            
            //checks to see which query has been selected and calls appropriate methods
            if (ddlReports.SelectedItem.ToString().Equals("Total cost by engineer"))
            {
                var results = from i in Monitor.Instance.Interventions where i.SiteEngineer.Id.Equals(engineerID) select i;
                decimal result = Decimal.Parse(report.TotalEngineerCost(engineerID));
                lblResultView.Text = Math.Round(result, 2).ToString();
                GridView1.DataSource = results;
                GridView1.DataBind();
            }
            else if(ddlReports.SelectedItem.ToString().Equals("Average cost by engineer"))
            {
                var results = from i in Monitor.Instance.Interventions where i.SiteEngineer.Id.Equals(engineerID) select i;
                decimal result = Decimal.Parse(report.AverageEngineerCost(engineerID));
                lblResultView.Text = Math.Round(result, 2).ToString();
                GridView1.DataSource = results;
                GridView1.DataBind();
            }
            else if(ddlReports.SelectedItem.ToString().Equals("Cost by district"))
            {
                var results = from i in Monitor.Instance.Interventions where i.Client.District.ID == int.Parse(districtID) select i;
                decimal result = Decimal.Parse(report.TotalDistrictCost(districtID));
                lblResultView.Text = Math.Round(result, 2).ToString();
                GridView1.DataSource = results;
                GridView1.DataBind();
            }
            //not funtional 
            else if(ddlReports.SelectedItem.ToString().Equals("Monthly costs for district"))
            {

            }
            else
            {

            }
            
            
            
        }

        //controls visibility of engineer and district control, hides and shows appropriate controls based on selected report.
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