using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using InterventionMonitor.DataAccess;
using Microsoft.AspNet.Identity;

namespace InterventionMonitor.Models
{
    // Thread-safe singleton pattern for Monitor that cannot be overridden by another class.
    public sealed class Monitor
    {
        static Monitor()
        {
        }

        private Monitor()
        {
        }
        
        private static readonly Monitor _instance = new Monitor();
        public static Monitor Instance
        {
            get
            {
                return _instance;
            }
        }

        public Approver FindApprover(string userId)
        {
            Approver approver = FindSiteEngineer(userId);
            if (approver == null)
            {
                approver = FindManager(userId);
            }
            return approver;
        }

        public Manager FindManager(string userId)
        {
            return Managers.FirstOrDefault(x => x.Id == userId);
        }

        List<Manager> _managers = new List<Manager>();
        bool managersIsLoaded = false;
        public List<Manager> Managers
        {
            get
            {
#if DEBUG
                if (!UnitTestDetector.IsInUnitTest)
#endif
                {
                    if (!managersIsLoaded)
                    {
                        var connection = DatabaseConnections.GetDataConnection();
                        var command = new SqlCommand(Manager.DBQueries.SelectAll, connection);
                        connection.Open();

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var manager = new Manager(reader);
                            _managers.Add(manager);
                        }
                        connection.Close();

                        managersIsLoaded = true;
                    }
                }
                return _managers;
            }
        }

        public SiteEngineer FindSiteEngineer(string userId)
        {
            return SiteEngineers.FirstOrDefault(x => x.Id == userId);
        }

        List<SiteEngineer> _siteEngineers = new List<SiteEngineer>();
        bool siteEngineersIsLoaded = false;
        public List<SiteEngineer> SiteEngineers
        {
            get
            {
#if DEBUG
                if (!UnitTestDetector.IsInUnitTest)
#endif
                {
                    if (!siteEngineersIsLoaded)
                    {
                        var connection = DatabaseConnections.GetDataConnection();
                        var command = new SqlCommand(SiteEngineer.DBQueries.SelectAll, connection);
                        connection.Open();

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var engineer = new SiteEngineer(reader);
                            _siteEngineers.Add(engineer);
                        }
                        connection.Close();

                        siteEngineersIsLoaded = true;
                    }
                }
                return _siteEngineers;
            }
        }

        public void Add(SiteEngineer engineer)
        {
            SiteEngineers.Add(engineer);
        }

        public Intervention FindIntervention(int interventionId)
        {
            return Interventions.FirstOrDefault(x => x.ID == interventionId);
        }

        List<Intervention> _interventions = new List<Intervention>();
        bool interventionsIsLoaded = false;
        public List<Intervention> Interventions
        {
            get
            {
#if DEBUG
                if (!UnitTestDetector.IsInUnitTest)
#endif
                {
                    if (!interventionsIsLoaded)
                    {
                        var connection = DatabaseConnections.GetDataConnection();
                        var command = new SqlCommand(Intervention.DBQueries.SelectAll, connection);
                        connection.Open();

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var intervention = new Intervention(reader);
                            _interventions.Add(intervention);
                        }
                        connection.Close();

                        interventionsIsLoaded = true;
                    }
                }
                return _interventions;
            }
        }

        public void Add(Intervention intervention)
        {
            Interventions.Add(intervention);
        }

        public Client FindClient(int clientId)
        {
            return Clients.FirstOrDefault(x => x.ID == clientId);
        }

        List<Client> _clients = new List<Client>();
        bool clientsIsLoaded = false;
        public List<Client> Clients
        {
            get
            {
#if DEBUG
                if (!UnitTestDetector.IsInUnitTest)
#endif
                {
                    if (!clientsIsLoaded)
                    {
                        var connection = DatabaseConnections.GetDataConnection();
                        var command = new SqlCommand(Client.DBQueries.SelectAll, connection);
                        connection.Open();

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var client = new Client(reader);
                            _clients.Add(client);
                        }
                        connection.Close();

                        clientsIsLoaded = true;
                    }
                }
                return _clients;
            }
        }

        public void Add(Client client)
        {
            Clients.Add(client);
        }
    }
}