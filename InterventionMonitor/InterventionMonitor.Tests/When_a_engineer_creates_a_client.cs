using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_engineer_creates_a_client
    {
        SiteEngineer siteEngineer;

        [TestInitialize]
        public void Setup()
        {
            siteEngineer = new SiteEngineer();
        }

        [TestMethod]
        public void With_a_non_null_name_it_will_successfully_add_a_client_in_the_same_district()
        {
            siteEngineer.District = Districts.Instance.Sydney;
            var clientA = siteEngineer.CreateClient("client A", null);
            Assert.IsNotNull(clientA);
            Assert.AreEqual(Districts.Instance.Sydney, clientA.District);
            CollectionAssert.Contains(Monitor.Instance.Clients, clientA);

            siteEngineer.District = Districts.Instance.RuralIndonesia;
            var clientB = siteEngineer.CreateClient("client B", null);
            Assert.IsNotNull(clientB);
            Assert.AreEqual(Districts.Instance.RuralIndonesia, clientB.District);
            CollectionAssert.Contains(Monitor.Instance.Clients, clientB);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void With_a_null_name_it_will_add_no_client()
        {
            var client = siteEngineer.CreateClient(null, null);
            Assert.IsNull(client);
            CollectionAssert.DoesNotContain(Monitor.Instance.Clients, client);
        }
    }
}
