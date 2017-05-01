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
            LoadInMemoryInterventions();
            GwInterventions.DataSource = Monitor.Instance.interventions;
            GwInterventions.DataBind();
        }

        // TODO: Todel
        void LoadInMemoryInterventions()
        {
            // TODO: Load from DB
            if (Monitor.Instance.interventions.Count == 0)
            {
                var intervention1 = new Intervention();
                intervention1.FillInValidTestData();
                var intervention2 = new Intervention();
                intervention2.FillInValidTestData();
                Monitor.Instance.interventions.Add(intervention1);
                Monitor.Instance.interventions.Add(intervention2);
            }
        }

        protected void GwInterventions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var selectedRowIndex = e.NewEditIndex;
            var interventionID = GwInterventions.Rows[selectedRowIndex].Cells[0].Text;
            Session["InterventionID"] = interventionID;

            Response.Redirect("EditIntervention.aspx");
        }
    }
}