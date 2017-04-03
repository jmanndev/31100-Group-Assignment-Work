using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class SiteEngineer : ApplicationUser
    {
        public District District
        {
            get;
            set;
        }

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

        public string Notes
        {
            get;
            set;
        }
    }
}