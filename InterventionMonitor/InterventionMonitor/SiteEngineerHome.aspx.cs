using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionMonitor
{
    public partial class SiteEngineerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnMyClients_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewClients.aspx");
        }

        protected void BtnMyInterventions_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewInterventions.aspx");
        }

        protected void BtnCreateClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateClient.aspx");
        }
    }
}