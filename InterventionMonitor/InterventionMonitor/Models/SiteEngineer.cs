﻿using System;
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

        public void CreateClient(string name)
        {
            if (name == null)
            {
                return;
            }

            var client = new Client();
            client.Name = name;
            Monitor.Instance.clients.Add(client);
        }
    }
}