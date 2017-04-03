using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class InterventionType
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

        public decimal LabourHours
        {
            get;
            set;
        }

        public decimal MaterialCost
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

        public Intervention Visit
        {
            get;
            set;
        }
    }
}