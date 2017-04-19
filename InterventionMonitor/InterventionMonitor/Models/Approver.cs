﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    /**
     * ApplicationUser is mapped to the DB and the app is trying to find its derived classes in the DB, causing errors whenever the DB is accessed.
     * So mark this derived class as not marked for now so a Discriminator column isn't needed.
     * **/
    [NotMapped] // Not mapped to the DB as of yet.
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