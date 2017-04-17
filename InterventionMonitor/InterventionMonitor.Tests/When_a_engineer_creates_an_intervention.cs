using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_engineer_creates_an_intervention
    {
        SiteEngineer siteEngineer;
        Client newestClient;

        [TestInitialize]
        public void Setup()
        {
            siteEngineer = new SiteEngineer();
            siteEngineer.District = Districts.Instance.Sydney;
            newestClient = siteEngineer.CreateClient("Josia");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void For_a_client_who_is_located_at_a_different_district_then_fail_to_create_intervention()
        {
            newestClient.District = Districts.Instance.RuralNewSouthWales;

            var interventionCreated = siteEngineer.CreateIntervention(newestClient);

            Assert.IsNull(interventionCreated);
            CollectionAssert.DoesNotContain(Monitor.Instance.interventions, interventionCreated);
        }

        [TestMethod]
        public void For_a_client_who_is_located_at_the_same_district_then_successfully_create_unsaved_intervention()
        {
            newestClient.District = Districts.Instance.Sydney;

            var interventionCreated = siteEngineer.CreateIntervention(newestClient);

            Assert.IsNotNull(interventionCreated);
            CollectionAssert.DoesNotContain(Monitor.Instance.interventions, interventionCreated);
        }
    }
}
