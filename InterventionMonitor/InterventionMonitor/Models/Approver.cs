using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Approver : ApplicationUser
    {
        public decimal HourLimit
        {
            get;
            set;
        }

        public decimal CostLimit
        {
            get;
            set;
        }

        public void ApproveIntervention(Intervention interventionToApprove)
        {
            if (interventionToApprove.CostRequired <= this.CostLimit && interventionToApprove.HoursRequired <= this.HourLimit)
            {
                interventionToApprove.IsMarkedAsApproved(this);
            }
        }
    }
}