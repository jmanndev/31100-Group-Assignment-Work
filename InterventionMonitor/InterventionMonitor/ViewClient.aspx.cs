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

        }

        protected void BtnCreateIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateIntervention.aspx");
        }
    }
}