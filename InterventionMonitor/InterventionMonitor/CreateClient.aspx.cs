using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterventionMonitor.Models;
using Microsoft.AspNet.Identity;

namespace InterventionMonitor
{
    public partial class CreateClient : System.Web.UI.Page
    {
        SiteEngineer engineer;
        protected void Page_Load(object sender, EventArgs e)
        {
            MemoriseEngineer();
            if (!IsPostBack)
            {
                PopulateDistrict();
            }
        }

        void MemoriseEngineer()
        {
            var userId = Page.User.Identity.GetUserId();
            if (userId != null)
            {
                engineer = Monitor.Instance.FindSiteEngineer(userId);
            }
        }

        void PopulateDistrict()
        {
            if (engineer != null)
            {
                lblDistrictValue.Text = engineer.District.Name;
            }
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (engineer != null)
                {
                    engineer.CreateClient(txtName.Text, txtAddress.Text);
                }
                Response.Redirect("ViewClients.aspx");
            }
        }
    }
}