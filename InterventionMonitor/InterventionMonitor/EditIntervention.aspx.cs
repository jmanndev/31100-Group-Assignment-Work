using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterventionMonitor.Models;

namespace InterventionMonitor
{
    public partial class EditIntervention : System.Web.UI.Page
    {
        Intervention intervention;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateIntervention();

                if (intervention != null)
                {
                    PopulateClient();
                    PopulateDistrict();
                    PopulateDate();
                    PopulateInterventionTypes();
                    PopulateHoursRequired();
                    PopulateCostRequired();
                    PopulateStatus();
                    PopulateLife();
                    PopulateNotes();
                }
            }
        }

        void PopulateIntervention()
        {
            var interventionIDRaw = Session["InterventionID"];
            int interventionID;
            if (interventionIDRaw != null && int.TryParse(interventionIDRaw.ToString(), out interventionID))
            {
                // TODO: Should InterventionID now be erased from the session?
                intervention = Monitor.Instance.interventions.Find(x => x.ID.Equals(interventionID));
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
    }
}