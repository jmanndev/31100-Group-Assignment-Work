using InterventionMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace InterventionMonitor.Models
{
    public class SiteEngineer : Approver
    {
        class DBColumnConstants
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Username = "Username";
            public const string DistrictId = "DistrictId";
            public const string HourApprovalLimit = "HourApprovalLimit";
            public const string CostApprovalLimit = "CostApprovalLimit";
            public const string Notes = "Notes";
        }

        public static class DBQueries
        {
            public static string SelectAll
            {
                get
                {
                    return @"SELECT Id, Name, Username, DistrictId, HourApprovalLimit, CostApprovalLimit, Notes
                        FROM Employee INNER JOIN SiteEngineer ON Employee.Id = SiteEngineer.EmployeeId";
                }
            }
        }

        public SiteEngineer()
        {
        }

        public SiteEngineer(SqlDataReader reader)
        {
            Id = reader[DBColumnConstants.Id].ToString();
            Name = reader[DBColumnConstants.Name].ToString();
            UserName = reader[DBColumnConstants.Username].ToString();
            var districtId = (int)reader[DBColumnConstants.DistrictId];
            District = Districts.Instance.FindDistrict(districtId);
            HourLimit = (decimal)reader[DBColumnConstants.HourApprovalLimit];
            CostLimit = (decimal)reader[DBColumnConstants.CostApprovalLimit];
            Notes = reader[DBColumnConstants.Notes].ToString();
        }

        public int ReturnMatchingClients()
        {
            int clientsInEngineerDistrict = 0;

            for (int i = 0; i < Monitor.Instance.Clients.Count; i++)
            {
               
                if (Monitor.Instance.Clients[i].District == this.District)
                    clientsInEngineerDistrict++;
            }
            return clientsInEngineerDistrict;
        }

        public Client CreateClient(string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", "name");
            var client = new Client(name, address, this.District);

            Monitor.Instance.Add(client);

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

            Monitor.Instance.Add(intervention);
            return intervention;
        }

        public Intervention CreateIntervention(Client client, DateTime date, InterventionType interventionType,
            decimal? overridingHoursRequired, decimal? overridingCostRequired, int remainingLife, string notes)
        {
            Intervention intervention = new Intervention(this, client, date, interventionType, 
                overridingHoursRequired, overridingCostRequired, remainingLife, notes);

            Monitor.Instance.Add(intervention);
            return intervention;
        }
    }
}