using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Approver : Employee, ITestableValidModel
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

        public District District
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public void ApproveIntervention(Intervention interventionToApprove)
        {
            if (CanApproveIntervention(interventionToApprove))
            {
                interventionToApprove.MarkedAsApproved(this);
            }
        }

        public bool CanApproveIntervention(Intervention interventionToApprove)
        {
            return HasCostApprovalLimitMoreThan(interventionToApprove.CostRequired) && HasHourApprovalLimitMoreThan(interventionToApprove.HoursRequired);
        }

        public bool HasCostApprovalLimitMoreThan(decimal cost)
        {
            return cost <= CostLimit;
        }

        public bool HasHourApprovalLimitMoreThan(decimal hours)
        {
            return hours <= HourLimit;
        }

        public string GetCostApprovalLimitErrorMessage()
        {
            return string.Format("Your cost approval limit is {0}AUD. You cannot approve this intervention.", CostLimit);
        }

        public string GetHourApprovalLimitErrorMessage()
        {
            return string.Format("Your hour approval limit is {0}. You cannot approve this intervention.", HourLimit);
        }

        #region Test-only region
#if DEBUG
        public void FillInValidTestData()
        {
            District = Districts.Instance.Sydney;
        }
#endif
        #endregion
    }
}