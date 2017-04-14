using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_SiteEngineer_approves_an_intervention
    {
        SiteEngineer siteEngineer;
        Intervention intervention;

        [TestInitialize]
        public void Setup()
        {
            siteEngineer = new SiteEngineer();
            intervention = new Intervention();
        }

        [TestMethod]
        public void When_the_cost_is_higher_than_their_quota_then_intervention_is_not_approved()
        {
            siteEngineer.CostLimit = 1;
            intervention.CostRequired = 9999;

            siteEngineer.ApproveIntervention(intervention);
            Assert.AreEqual(intervention.isApproved, false);
        }

        [TestMethod]
        public void When_the_cost_is_lower_than_their_quota_then_intervention_is_approved()
        {
            siteEngineer.CostLimit = 9999;
            intervention.CostRequired = 1;

            siteEngineer.ApproveIntervention(intervention);
            Assert.AreEqual(intervention.isApproved, true);
        }

        [TestMethod]
        public void When_the_cost_is_equal_to_their_quota_then_intervention_is_approved()
        {
            siteEngineer.CostLimit = 1;
            intervention.CostRequired = 1;

            siteEngineer.ApproveIntervention(intervention);
            Assert.AreEqual(intervention.isApproved, true);
        }
    }
}
