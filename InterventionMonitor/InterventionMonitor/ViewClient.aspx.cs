using InterventionMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionMonitor
{
    public partial class ViewClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // REPLACE THIS CODE TO PULL DATA FOR INDIVIDUAL CLIENT FROM DB
            
            txtName.Text = "Database Name";
            txtAddress.Text = "Database Address";
            txtNotes.Text = "Database Notes";

            LbInterventions.DataSource = Monitor.Instance.interventions;
            LbInterventions.DataTextField = "DisplayValue";
            LbInterventions.DataBind();
        }

        protected void BtnCreateIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateIntervention.aspx");
        }
    }
}