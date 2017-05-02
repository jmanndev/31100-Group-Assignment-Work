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
    public partial class CreateIntervention : System.Web.UI.Page
    {
        SiteEngineer engineer;
        protected void Page_Load(object sender, EventArgs e)
        {
            MemoriseEngineer();

            if (!IsPostBack)
            {
                PopulateClients();
                PopulateDistrict();
                PopulateDate();
                PopulateInterventionTypesAndDefaultHoursAndCost();
                PopulateStatus();
                PopulateCustomValidatorErrorMessages();
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

        void PopulateClients()
        {
            ddlClient.DataSource = Monitor.Instance.Clients;
            ddlClient.DataTextField = "Name";
            ddlClient.DataBind();
        }

        void PopulateDistrict()
        {
            if (engineer != null)
            {
                lblDistrictValue.Text = engineer.District.Name;
            }
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

        private void PopulateCustomValidatorErrorMessages()
        {
            if (engineer != null)
            {
                cvCostApproval.ErrorMessage = engineer.GetCostApprovalLimitErrorMessage();
                cvHourApproval.ErrorMessage = engineer.GetHourApprovalLimitErrorMessage();
            }
        }

        protected void ProposeButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                ProposeIntervention();
                Response.Redirect("ViewInterventions.aspx");
            }
        }

        Intervention ProposeIntervention()
        {
            Intervention result = null;
            if (engineer != null)
            {
                var client = Monitor.Instance.Clients[ddlClient.SelectedIndex];
                var type = InterventionTypes.Instance.AllTypes[ddlType.SelectedIndex];
                var hoursRequired = decimal.Parse(txtHoursRequired.Text);
                var costRequired = decimal.Parse(txtCostRequired.Text);
                var date = DateTime.Parse(txtDate.Text);
                var notes = txtNotes.Text;
                var life = int.Parse(txtRemainingLife.Text);
                result = engineer.CreateIntervention(client, date, type, hoursRequired, costRequired, life, notes);
            }
            return result;
        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            if (IsValid && engineer != null)
            {
                var intervention = ProposeIntervention();
                engineer.ApproveIntervention(intervention);
                Response.Redirect("ViewInterventions.aspx");
            }
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

        protected void cvCostApproval_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (engineer != null)
            {
                var cost = decimal.Parse(txtCostRequired.Text);
                args.IsValid = engineer.HasCostApprovalLimitMoreThan(cost);
            }
        }

        protected void cvHourApproval_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (engineer != null)
            {
                var hour = decimal.Parse(txtHoursRequired.Text);
                args.IsValid = engineer.HasHourApprovalLimitMoreThan(hour);
            }
        }
    }
}