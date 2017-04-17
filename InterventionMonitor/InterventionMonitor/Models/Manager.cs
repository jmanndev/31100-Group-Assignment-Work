using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Manager : Approver
    {
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
    }
}