using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    // Thread-safe singleton pattern for Monitor that cannot be overridden by another class.
    public sealed class Monitor
    {
        // load containers of users and clients into memory.
        public List<Accountant> accountants = new List<Accountant>();
        public List<SiteEngineer> siteEngineers = new List<SiteEngineer>();
        public List<Manager> managers = new List<Manager>();
        public List<Client> clients = new List<Client>();
        public List<District> districts = new List<District>();

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
    }
}