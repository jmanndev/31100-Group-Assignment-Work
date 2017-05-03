using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_engineer_views_clients
    {
        SiteEngineer siteEngineerA;

        int clientsInSydney;

        [TestInitialize]
        public void Setup()
        {
            siteEngineerA = new SiteEngineer();

            siteEngineerA.District = Districts.Instance.Sydney;

            clientsInSydney = 0;
            for(int i = 0; i < Monitor.Instance.Clients.Count; i++)
            {
                if (Monitor.Instance.Clients[i].District == siteEngineerA.District)
                    clientsInSydney++;
            }
            //SiteEngineer at Sydney has created 3 extra separate clients
            //This count will attempt to match the Assert.AreEqual checker.
            for (int i = 0; i < 3; i++)
            {
                siteEngineerA.CreateClient("ClientA" + i, null);
                clientsInSydney++;
            }
        }

        [TestMethod]
        public void In_their_current_district_then_display_matching_amount_of_clients_in_current_district()
        {
            int matchedClients = siteEngineerA.ReturnMatchingClients();
            Assert.AreEqual(clientsInSydney, matchedClients);

            
        }
    }
}
