using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterventionMonitor.Models;

namespace InterventionMonitor
{
    public partial class CreateIntervention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateClients();
                PopulateDistrict();
                PopulateDate();
                PopulateInterventionTypesAndDefaultHoursAndCost();
                PopulateStatus();
            }
        }

        void PopulateClients()
        {
            ddlClient.DataSource = Monitor.Instance.clients; // TODO: Populate with clients current user can see
            ddlClient.DataTextField = "Name";
            ddlClient.DataBind();
        }

        void PopulateDistrict()
        {
            // TODO: Populate with current user's district
        }

        void PopulateDate()
        {
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        void PopulateInterventionTypesAndDefaultHoursAndCost()
        {
            ddlType.DataSource = InterventionTypes.Instance.AllTypes;
            ddlType.DataTextField = "Name";
            ddlType.DataBind();
            SetDefaultHoursAndCostFromSelectedType();
        }

        InterventionType GetSelectedInterventionType()
        {
            var selectedIndex = ddlType.SelectedIndex;
            return InterventionTypes.Instance.AllTypes[selectedIndex];
        }

        void PopulateStatus()
        {
            lblStatusValue.Text = InterventionStatuses.Instance.Proposed.Name;
        }

        protected void ProposeButton_Click(object sender, EventArgs e)
        {
        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
        }

        protected void ckbDefaultHoursRequired_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDefaultHoursRequired.Checked)
            {
                txtHoursRequired.ReadOnly = true;
                txtHoursRequired.Enabled = false;
                PopulateHoursRequiredFromSelectedType();
            }
            else
            {
                txtHoursRequired.ReadOnly = false;
                txtHoursRequired.Enabled = true;
            }
        }

        void PopulateHoursRequiredFromSelectedType()
        {
            txtHoursRequired.Text = GetSelectedInterventionType().LabourHours.ToString();
        }

        protected void ckbDefaultCostRequired_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDefaultCostRequired.Checked)
            {
                txtCostRequired.ReadOnly = true;
                txtCostRequired.Enabled = false;
                PopulateCostRequiredFromSelectedType();
            }
            else
            {
                txtCostRequired.ReadOnly = false;
                txtCostRequired.Enabled = true;
            }
        }

        void PopulateCostRequiredFromSelectedType()
        {
            txtCostRequired.Text = GetSelectedInterventionType().MaterialCost.ToString();
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDefaultHoursAndCostFromSelectedType();
        }

        void SetDefaultHoursAndCostFromSelectedType()
        {
            PopulateHoursRequiredFromSelectedType();
            PopulateCostRequiredFromSelectedType();
        }
    }
}