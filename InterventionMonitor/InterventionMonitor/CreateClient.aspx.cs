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
        Monitor monitor = Monitor.Instance;
        SiteEngineer siteEngi = new SiteEngineer();

        protected void Page_Load(object sender, EventArgs e)
        {
            //populating dummy data 
            siteEngi.UserName = "Bob";
            siteEngi.District = Districts.Instance.RuralNewSouthWales;
            monitor.siteEngineers.Add(siteEngi);
            monitor.districts.Add(Districts.Instance.RuralNewSouthWales);
            monitor.districts.Add(Districts.Instance.UrbanIndonesia);
            ddlDistrict.DataSource = monitor.districts;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //badly coded just for demo purpose
            siteEngi.CreateClient(txtName.Text);
            Response.Redirect("ViewClients.aspx");
        }
    }
}