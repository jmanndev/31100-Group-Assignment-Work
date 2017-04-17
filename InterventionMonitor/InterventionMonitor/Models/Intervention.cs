using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Intervention
    {
        public Intervention()
        {
            Status = InterventionStatuses.Instance.Proposed;
        }

        public Intervention(SiteEngineer siteEngineer, Client client, InterventionType interventionType)
        {
            RequestedBy = siteEngineer;
            Client = client;
            Type = interventionType;
        }

        [Key]
        public int ID
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public District District
        {
            get;
            set;
        }

        public Client Client
        {
            get;
            set;
        }

        // Jenny: is this calculated from related InterventionTypes's LabourHours and then stored for faster queries?
        public int HoursRequired
        {
            get;
            set;
        }

        // Jenny: is this calculated from related InterventionTypes's MaterialCost and then stored for faster queries?
        public int CostRequired
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public Intervention PreviousVisit
        {
            get;
            set;
        }

        public SiteEngineer RequestedBy
        {
            get;
            set;
        }

        public ApplicationUser ApprovedBy
        {
            get;
            set;
        }

        public InterventionType Type
        {
            get;
            set;
        }

        public bool IsApproved
        {
            get { return Status == InterventionStatuses.Instance.Approved; }
        }

        public InterventionStatus Status
        {
            get;
            set;
        }

        /*
         * @param approver - should eventually be restricted to user types who are allowed to approve interventions.
         * */
        public void IsMarkedAsApproved(ApplicationUser approver)
        {
            if (Status == InterventionStatuses.Instance.Proposed)
            {
                ApprovedBy = approver;
                Status = InterventionStatuses.Instance.Approved;
            }
        }

        public string DisplayValue
        {
            get
            {
                return Client.Name + " - " + Type.Name;
            }
        }
            
    }
}
 