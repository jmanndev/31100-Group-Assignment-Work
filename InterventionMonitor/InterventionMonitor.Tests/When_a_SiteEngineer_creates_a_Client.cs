using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_SiteEngineer_creates_a_client
    {
        SiteEngineer siteEngineer;

        [TestInitialize]
        public void Setup()
        {
            siteEngineer = new SiteEngineer();
        }

        [TestMethod]
        public void With_a_non_null_name_it_will_successfully_add_a_client()
        {
            var previousCount = Monitor.Instance.clients.Count;
            siteEngineer.CreateClient("payless shoes");

            int expectedCount = previousCount + 1;

            Assert.AreEqual(expectedCount, Monitor.Instance.clients.Count);
        }

        [TestMethod]
        public void With_a_null_name_it_will_add_no_client()
        {
            var previousCount = Monitor.Instance.clients.Count;
            siteEngineer.CreateClient(null);

            Assert.AreEqual(previousCount, Monitor.Instance.clients.Count);
        }
    }
}
