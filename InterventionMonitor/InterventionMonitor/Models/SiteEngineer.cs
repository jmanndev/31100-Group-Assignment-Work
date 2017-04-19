using System;
using System.Collections.Generic;
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
            if (name == null)
                throw new ArgumentException("client should have name");

            var client = new Client();
            client.Name = name;
            client.Address = address;
            client.District = this.District;
            Monitor.Instance.clients.Add(client);

            return client;
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

            Monitor.Instance.interventions.Add(intervention);
            return intervention;
        }
    }
}