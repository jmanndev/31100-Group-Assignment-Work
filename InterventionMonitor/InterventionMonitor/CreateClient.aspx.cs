using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterventionMonitor.Models;

namespace InterventionMonitor
{
    public partial class CreateClient : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            ddlDistrict.DataSource = Monitor.Instance.districts;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //badly coded just for demo purpose
            Monitor.Instance.siteEngineers.First().CreateClient(txtName.Text);
            Response.Redirect("ViewClients.aspx");
        }
    }
}