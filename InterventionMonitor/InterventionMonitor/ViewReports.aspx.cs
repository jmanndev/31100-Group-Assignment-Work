using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionMonitor
{
    public partial class ViewReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> reports = new List<string>();
            reports.Add("Total cost by engineer");
            reports.Add("Average cost by engineer");
            reports.Add("Cost by District");
            reports.Add("Monthly costs for district");
            ddlReports.DataSource = reports;
            ddlReports.DataBind();
        }
    }
}