using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_engineer_views_clients
    {
        SiteEngineer siteEngineerA;
        SiteEngineer siteEngineerB;
        SiteEngineer siteEngineerC;

        int clientsInSydney;

        [TestInitialize]
        public void Setup()
        {
            siteEngineerA = new SiteEngineer();
            siteEngineerB = new SiteEngineer();
            siteEngineerC = new SiteEngineer();

            siteEngineerA.District = Districts.Instance.Sydney;
            siteEngineerB.District = Districts.Instance.RuralIndonesia;
            siteEngineerC.District = Districts.Instance.UrbanIndonesia;

            //SiteEngineer at Sydney has created 3 separate clients
            //This count will attempt to match the Assert.AreEqual checker.
            clientsInSydney = 0;

            for(int i = 0; i < 3; i++)
            {
                siteEngineerA.CreateClient("ClientA" + i, null);
                clientsInSydney++;
            }

            /*
            siteEngineerA.CreateClient("ClientA1", null);
            siteEngineerA.CreateClient("ClientA2", null);
            siteEngineerA.CreateClient("ClientA3", null);
            */

            siteEngineerB.CreateClient("ClientB1", null);
            siteEngineerB.CreateClient("ClientB2", null);

            siteEngineerC.CreateClient("ClientC1", null);
        }

        [TestMethod]
        public void In_their_current_district_then_display_matching_amount_of_clients_in_current_district()
        {
            int matchedClients = siteEngineerA.ReturnMatchingClients();
            Assert.AreEqual(clientsInSydney, matchedClients);
        }
    }
}
