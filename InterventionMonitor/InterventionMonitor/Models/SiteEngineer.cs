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

        public Intervention CreateIntervention(Client client)
        {
            if (this.District != client.District)
                throw new ArgumentException("engineer should be same district as client");

            return new Intervention();
        }

        public Intervention CreateIntervention(Client client, InterventionType interventionType)
        {
            Intervention intervention = new Intervention(this, client, interventionType);
            //Continue on creating intervention, return true if
            //intervention was created successful
            return intervention;
        }
        
        
        /* * Function could be moved to parent class if other types of users can approve interventions.  
         **/
        public bool ApproveIntervention(Intervention interventionToApprove)
        {
            if (interventionToApprove.CostRequired > this.CostLimit)
            {
                return false;
            }

            interventionToApprove.ApproveIntervention(this);
            //add more checking of approval criteria here
            //return true if intervention is successfully approved
            return true;
        }
    }
}