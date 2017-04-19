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
        }
        
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            bool allFieldsPopulated = true; //make this variable name better...
            string errorMessage = "";

            if (txtName.Text.ToString().Equals(""))
            {
                allFieldsPopulated = false;
                errorMessage += "** Name is required.\n\n";
            }
            
            if (allFieldsPopulated)
            {
                Monitor.Instance.siteEngineers.First().CreateClient(txtName.Text, txtAddress.Text);
                Response.Redirect("ViewClients.aspx");
            }
            else
            {
                lblErrorMessage.Text = errorMessage;
            }
        }
    }
}