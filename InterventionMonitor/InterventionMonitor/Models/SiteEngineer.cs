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

        public int ReturnMatchingClients()
        {
            int clientsInEngineerDistrict = 0;

            for (int i = 0; i < Monitor.Instance.clients.Count; i++)
            {
               
                if (Monitor.Instance.clients[i].District == this.District)
                    clientsInEngineerDistrict++;
            }
            return clientsInEngineerDistrict;
        }

        public Client CreateClient(string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", "name");
            var client = new Client(name, address, this.District);

            Monitor.Instance.clients.Add(client);

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

        public Intervention CreateIntervention(Client client, DateTime date, InterventionType interventionType,
            decimal? overridingHoursRequired, decimal? overridingCostRequired, int remainingLife, string notes)
        {
            Intervention intervention = new Intervention(this, client, date, interventionType, 
                overridingHoursRequired, overridingCostRequired, remainingLife, notes);

            Monitor.Instance.interventions.Add(intervention);
            return intervention;
        }
    }
}