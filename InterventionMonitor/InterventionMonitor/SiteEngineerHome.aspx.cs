using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterventionMonitor.Models;

namespace InterventionMonitor
{
    public partial class SiteEngineerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Monitor monitor = Monitor.Instance;
            SiteEngineer siteEngi = new SiteEngineer();

            if (Monitor.Instance.districts.Count == 0)
            {
                //populating dummy data 
                siteEngi.UserName = "Bob";
                siteEngi.District = Districts.Instance.RuralNewSouthWales;
                monitor.siteEngineers.Add(siteEngi);
                monitor.districts.Add(Districts.Instance.RuralNewSouthWales);
                monitor.districts.Add(Districts.Instance.UrbanIndonesia);
                siteEngi.CreateClient("Troy");
                InterventionType type = new InterventionType();
                type.Name = "Mozzie net";
                siteEngi.CreateIntervention(monitor.clients.Where(x => x.Name == "Troy").First(), type);
            }
            else
            {

            }
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