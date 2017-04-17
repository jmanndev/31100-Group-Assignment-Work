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
            LbInterventions.DataSource = Monitor.Instance.interventions;
            LbInterventions.DataTextField = "DisplayValue";
            LbInterventions.DataBind();
        }
    }
}