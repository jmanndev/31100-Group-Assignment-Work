using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Intervention : ITestableValidModel
    {
        public Intervention()
        {
            ID = Monitor.Instance.interventions.Count + 1; // TODO: hack, get rid as DB will fix the unique ID issue
            Status = InterventionStatuses.Instance.Proposed;
        }

        public Intervention(SiteEngineer siteEngineer, Client client, InterventionType interventionType)
            : this()
        {
            RequestedBy = siteEngineer;
            Client = client;
            Type = interventionType;
        }

        public Intervention(SiteEngineer engineer, Client client, DateTime date, InterventionType interventionType,
            decimal? overridingHoursRequired, decimal? overridingCostRequired, int remainingLife, string notes)
            : this()
        {
            RequestedBy = engineer;
            Client = client;
            Date = date;
            Type = interventionType;
            HoursRequired = overridingHoursRequired != null ? (decimal)overridingHoursRequired : Type.LabourHours;
            CostRequired = overridingCostRequired != null ? (decimal)overridingCostRequired : Type.MaterialCost;
            Life = remainingLife;
            Notes = notes;
        }

        #region Properties Stored In DB (Persistent Properties)

        [Key]
        public int ID
        {
            get;
            set;
        }

        public Client Client
        {
            get;
            set;
        }

        public InterventionType Type
        {
            get;
            set;
        }

        public decimal HoursRequired
        {
            get;
            set;
        }

        public decimal CostRequired
        {
            get;
            set;
        }

        public SiteEngineer RequestedBy
        {
            get;
            set;
        }
        
        public DateTime Date
        {
            get;
            set;
        }

        public InterventionStatus Status
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public int Life
        {
            get;
            set;
        }

        public Approver ApprovedBy
        {
            get;
            set;
        }

        #endregion

        public bool IsApproved
        {
            get { return Status == InterventionStatuses.Instance.Approved; }
        }

        public void MarkedAsApproved(Approver approver)
        {
            if (Status == InterventionStatuses.Instance.Proposed)
            {
                ApprovedBy = approver;
                Status = InterventionStatuses.Instance.Approved;
            }
        }

        public DateTime LastVisitDate
        {
            get
            {
                // TODO: Test this to use the Inspection class (which needs to be made)
                return Date;
            }
        }

        #region Fields to be bound to controls

        public string DisplayClient
        {
            get { return Client.Name; }
        }

        public string DisplayDistrict
        {
            get { return Client.District.Name; }
        }

        public string DisplayType
        {
            get { return Type.Name; }
        }

        public string DisplayDate
        {
            get { return Date.ToLongDateString(); }
        }

        public string DisplayHours
        {
            get { return HoursRequired.ToString(); }
        }

        public string DisplayCost
        {
            get { return string.Format("{0}AUD", CostRequired); }
        }

        public string DisplayStatus
        {
            get { return Status.Name; }
        }

        #endregion

        #region Test-only code
#if DEBUG
        public void FillInValidTestData()
        {
            var engineer = new SiteEngineer();
            engineer.District = Districts.Instance.Sydney;
            var client = engineer.CreateClient("Jenny", "");
            RequestedBy = engineer;
            Client = client;
            Date = DateTime.Now;
            Type = InterventionTypes.Instance.SupplyAndInstallStormproofHomeKit;
            HoursRequired = InterventionTypes.Instance.SupplyAndInstallStormproofHomeKit.LabourHours;
            CostRequired = InterventionTypes.Instance.SupplyAndInstallStormproofHomeKit.MaterialCost;
            Life = 100;
            Notes = "";
        }
#endif
        #endregion
    }
}
 