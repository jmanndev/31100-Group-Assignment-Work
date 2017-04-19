using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_approver_approves_an_intervention
    {
        Approver approver;
        Intervention intervention;

        [TestInitialize]
        public void Setup()
        {
            approver = new Approver();
            intervention = new Intervention();
        }

        [TestMethod]
        public void As_an_engineer_the_behaviour_should_be_inherited()
        {
            SiteEngineer engineer = new SiteEngineer();
            Assert.IsInstanceOfType(engineer, typeof(Approver));
        }

        [TestMethod]
        public void As_a_manager_the_behaviour_should_be_inherited()
        {
            Manager manager = new Manager();
            Assert.IsInstanceOfType(manager, typeof(Approver));
        }

        [TestMethod]
        public void When_the_cost_and_hours_is_higher_than_their_quota_then_intervention_is_not_approved()
        {
            approver.CostLimit = 1;
            intervention.CostRequired = 9999;
            approver.HourLimit = 1;
            intervention.HoursRequired = 9999;

            approver.ApproveIntervention(intervention);
            Assert.IsFalse(intervention.IsApproved);
            Assert.IsNull(intervention.ApprovedBy);
        }

        [TestMethod]
        public void When_the_cost_is_lower_but_hours_is_higher_than_their_quota_then_intervention_is_not_approved()
        {
            approver.CostLimit = 9999;
            intervention.CostRequired = 1;
            approver.HourLimit = 1;
            intervention.HoursRequired = 9999;

            approver.ApproveIntervention(intervention);
            Assert.IsFalse(intervention.IsApproved);
            Assert.IsNull(intervention.ApprovedBy);
        }

        [TestMethod]
        public void When_the_cost_is_higher_but_hours_is_lower_than_their_quota_then_intervention_is_not_approved()
        {
            approver.CostLimit = 1;
            intervention.CostRequired = 9999;
            approver.HourLimit = 9999;
            intervention.HoursRequired = 1;

            approver.ApproveIntervention(intervention);
            Assert.IsFalse(intervention.IsApproved);
            Assert.IsNull(intervention.ApprovedBy);
        }

        [TestMethod]
        public void When_the_cost_and_hours_is_equal_to_their_quota_then_intervention_is_approved()
        {
            approver.CostLimit = 1;
            intervention.CostRequired = 1;
            approver.HourLimit = 1;
            intervention.HoursRequired = 1;

            approver.ApproveIntervention(intervention);
            Assert.IsTrue(intervention.IsApproved);
            Assert.AreEqual(approver, intervention.ApprovedBy);
        }

        [TestMethod]
        public void When_the_cost_and_hours_is_lower_to_their_quota_then_intervention_is_approved()
        {
            approver.CostLimit = 9999;
            intervention.CostRequired = 1;
            approver.HourLimit = 9999;
            intervention.HoursRequired = 1;

            approver.ApproveIntervention(intervention);
            Assert.IsTrue(intervention.IsApproved);
            Assert.AreEqual(approver, intervention.ApprovedBy);
        }

        [TestMethod]
        public void When_the_intervention_is_completed_then_intervention_cannot_change_back_to_approved()
        {
            intervention.Status = InterventionStatuses.Instance.Completed;
            approver.ApproveIntervention(intervention);
            Assert.IsFalse(intervention.IsApproved);
            Assert.IsNull(intervention.ApprovedBy);
        }

        [TestMethod]
        public void When_the_intervention_is_cancelled_then_intervention_cannot_change_back_to_approved()
        {
            intervention.Status = InterventionStatuses.Instance.Cancelled;
            approver.ApproveIntervention(intervention);
            Assert.IsFalse(intervention.IsApproved);
            Assert.IsNull(intervention.ApprovedBy);
        }
    }
}
