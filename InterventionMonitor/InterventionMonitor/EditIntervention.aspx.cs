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
    public partial class EditIntervention : System.Web.UI.Page
    {
        Intervention intervention;
        Approver approver;

        protected void Page_Load(object sender, EventArgs e)
        {
            MemoriseApprover();
            MemoriseIntervention();

            if (!IsPostBack)
            {
                if (intervention != null)
                {
                    PopulateClient();
                    PopulateDistrict();
                    PopulateDate();
                    PopulateInterventionTypes();
                    PopulateHoursRequired();
                    PopulateCostRequired();
                    PopulateStatus();
                    PopulateRequestedByAndApprovedBy();
                    PopulateLife();
                    PopulateNotes();
                    SetVisibilityOfButtons();
                }
            }
        }

        private void MemoriseApprover()
        {
            var userId = Page.User.Identity.GetUserId();
            if (userId != null)
            {
                approver = Monitor.Instance.FindApprover(userId);
            }
        }

        void MemoriseIntervention()
        {
            var interventionIDRaw = Session["InterventionID"];
            int interventionID;
            if (interventionIDRaw != null && int.TryParse(interventionIDRaw.ToString(), out interventionID))
            {
                intervention = Monitor.Instance.FindIntervention(interventionID);
            }
        }

        void PopulateClient()
        {
            lblClientValue.Text = intervention.DisplayClient;
        }

        void PopulateDistrict()
        {
            lblDistrictValue.Text = intervention.DisplayDistrict;
        }

        void PopulateDate()
        {
            lblDateValue.Text = intervention.Date.ToString("yyyy-MM-dd");
        }

        void PopulateInterventionTypes()
        {
            lblTypeValue.Text = intervention.DisplayType;
        }

        private void PopulateHoursRequired()
        {
            lblHoursRequiredValue.Text = intervention.DisplayHours;
        }

        private void PopulateCostRequired()
        {
            lblCostRequiredValue.Text = intervention.DisplayCost;
        }

        private void PopulateRequestedByAndApprovedBy()
        {
            lblRequestedByValue.Text = intervention.DisplayEngineer;
            lblApprovedByValue.Text = intervention.DisplayApprover;
        }

        void PopulateStatus()
        {
            lblStatusValue.Text = InterventionStatuses.Instance.Proposed.Name;
        }

        private void PopulateLife()
        {
            txtRemainingLife.Text = intervention.Life.ToString();
        }

        private void PopulateNotes()
        {
            txtNotes.Text = intervention.Notes;
        }

        private void SetVisibilityOfButtons()
        {
            if (intervention != null && approver != null)
            {
                if (intervention.IsApproved)
                {
                    btnApprove.Visible = false;
                }
                else
                {
                    btnApprove.Enabled = approver.CanApproveIntervention(intervention);
                    btnCancel.Visible = false;
                    btnComplete.Visible = false;
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (intervention != null && approver != null)
            {
                var life = int.Parse(txtRemainingLife.Text);
                var notes = txtNotes.Text;
                intervention.Update(life, notes);
                approver.ApproveIntervention(intervention);
                Response.Redirect("ViewInterventions.aspx");
            }
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            if (intervention != null && approver != null)
            {
                var life = int.Parse(txtRemainingLife.Text);
                var notes = txtNotes.Text;
                intervention.Complete(life, notes);
                Response.Redirect("ViewInterventions.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (intervention != null && approver != null)
            {
                var life = int.Parse(txtRemainingLife.Text);
                var notes = txtNotes.Text;
                intervention.Cancel(life, notes);
                Response.Redirect("ViewInterventions.aspx");
            }
        }
    }
}