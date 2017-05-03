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
            AllStatuses.Add(Proposed);
            AllStatuses.Add(Approved);
            AllStatuses.Add(Cancelled);
            AllStatuses.Add(Completed);
        }

        private static readonly InterventionStatuses _instance = new InterventionStatuses();
        public static InterventionStatuses Instance
        {
            get
            {
                return _instance;
            }
        }

        public InterventionStatus FindStatus(int statusId)
        {
            return AllStatuses.FirstOrDefault(x => x.ID == statusId);
        }

        // These match with what's in the DB
        public InterventionStatus Proposed = new InterventionStatus() { ID = 1, Name = "Proposed" };
        public InterventionStatus Approved = new InterventionStatus() { ID = 2, Name = "Approved" };
        public InterventionStatus Cancelled = new InterventionStatus() { ID = 3, Name = "Cancelled" };
        public InterventionStatus Completed = new InterventionStatus() { ID = 4, Name = "Completed" };
        readonly List<InterventionStatus> AllStatuses = new List<InterventionStatus>();
    }
}