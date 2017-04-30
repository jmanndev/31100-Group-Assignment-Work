using InterventionMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class SiteEngineer : Approver
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

        public Client CreateClient(string name, string address)
        {
            if (name == null && name.Equals(""))
                throw new ArgumentException("Name is required", "name");
            var client = new Client(name, address, this.District);
            
            //client.ID = Monitor.Instance.clients.Count; // TODO: hack, get rid as DB will fix the unique ID issue
            //Monitor.Instance.clients.Add(client);

            return client;
        }

        public Intervention CreateIntervention(Client client)
        {
            if (this.District != client.District)
                throw new ArgumentException("Engineer should be same district as the client");

            return new Intervention();
        }

        public Intervention CreateIntervention(Client client, InterventionType interventionType)
        {
            Intervention intervention = new Intervention(this, client, interventionType);

            Monitor.Instance.interventions.Add(intervention);
            return intervention;
        }
    }
}