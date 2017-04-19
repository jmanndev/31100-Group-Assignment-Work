using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_engineer_creates_an_intervention_for_a_client_in_same_district
    {
        SiteEngineer siteEngineer;
        Client newestClient;

        [TestInitialize]
        public void Setup()
        {
            siteEngineer = new SiteEngineer();
            siteEngineer.District = Districts.Instance.Sydney;
            newestClient = siteEngineer.CreateClient("Josia", null);
            newestClient.District = Districts.Instance.Sydney;
        }

        [TestMethod]
        public void With_intervention_type_mosquito_net_will_be_created_with_correct_client_and_type()
        {
            Intervention intervention = siteEngineer.CreateIntervention(newestClient, InterventionTypes.Instance.SupplyMosquitoNet);

            Assert.AreEqual(InterventionTypes.Instance.SupplyMosquitoNet, intervention.Type);
        }
    }
}
