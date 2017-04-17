using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_SiteEngineer_creates_an_intervention
    {
        SiteEngineer siteEngineer;
        Client newestClient;

        [TestInitialize]
        public void Setup()
        {
            siteEngineer = new SiteEngineer();
            siteEngineer.District = Districts.Instance.Sydney;
            siteEngineer.CreateClient("Josia");
            newestClient = Monitor.Instance.GetNewestClient();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void For_a_client_who_is_located_at_a_different_district_then_fail_to_create_intervention()
        {
            newestClient.District = Districts.Instance.RuralNewSouthWales;

            var interventionCreated = siteEngineer.CreateIntervention(newestClient);

            Assert.IsNull(interventionCreated);
        }

        [TestMethod]
        public void For_a_client_who_is_located_at_the_same_district_then_successfully_create_intervention()
        {
            newestClient.District = Districts.Instance.Sydney;

            var interventionCreated = siteEngineer.CreateIntervention(newestClient);

            Assert.IsNotNull(interventionCreated);
        }
    }
}
