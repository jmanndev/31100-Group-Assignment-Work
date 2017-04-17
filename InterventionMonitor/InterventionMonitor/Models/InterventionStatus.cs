using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class InterventionStatus
    {
        [Key]
        public int ID
        {
            get;
            set;
        }

        public string Name
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

    // Thread-safe singleton pattern for InterventionStatuses that cannot be overridden by another class.
    public sealed class InterventionStatuses
    {
        static InterventionStatuses()
        {
        }

        private InterventionStatuses()
        {
        }

        private static readonly InterventionStatuses _instance = new InterventionStatuses();
        public static InterventionStatuses Instance
        {
            get
            {
                return _instance;
            }
        }
        public InterventionStatus Proposed = new InterventionStatus() { Name = "Proposed" };
        public InterventionStatus Approved = new InterventionStatus() { Name = "Approved" };
        public InterventionStatus Cancelled = new InterventionStatus() { Name = "Cancelled" };
        public InterventionStatus Completed = new InterventionStatus() { Name = "Completed" };
    }
}