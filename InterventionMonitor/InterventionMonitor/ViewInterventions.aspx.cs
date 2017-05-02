using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterventionMonitor.Models;

namespace InterventionMonitor
{
    public partial class ViewInterventions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GwInterventions.DataSource = Monitor.Instance.Interventions;
                GwInterventions.DataBind();

                btnCreateIntervention.Visible = Page.User.IsInRole("Site Engineer");
            }
        }

        protected void GwInterventions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var selectedRowIndex = e.NewEditIndex;
            var interventionID = GwInterventions.Rows[selectedRowIndex].Cells[0].Text;
            Session["InterventionID"] = interventionID;

            Response.Redirect("EditIntervention.aspx");
        }

        protected void btnCreateIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateIntervention.aspx");
        }
    }
}