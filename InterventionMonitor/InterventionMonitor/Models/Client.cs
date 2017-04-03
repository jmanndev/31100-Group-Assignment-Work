using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Client
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

        public District District
        {
            get;
            set;
        }

        // TODO: Add the rest of the properties. See DB diagram.
    }
}