using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Intervention
    {
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

        /* Jenny:
         * Using the DB diagram as reference, Life looks to belong
         * to InterventionType instead. Also renamed:
         * - "SiteEngineer" to "RequestedBy"
         * - "LastVisit" to "PreviousVisit".
         **/
    }
}
 