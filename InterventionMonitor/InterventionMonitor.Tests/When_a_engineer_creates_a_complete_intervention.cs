using System;
using InterventionMonitor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_a_engineer_creates_a_complete_intervention
    {
        SiteEngineer engineer;
        Client client;
        InterventionType type;

        [TestInitialize]
        public void Setup()
        {
            engineer = new SiteEngineer();
            engineer.District = Districts.Instance.Sydney;
            client = engineer.CreateClient("Josia", null);
            type = new InterventionType();
            type.LabourHours = 30;
            type.MaterialCost = 300;
        }

        [TestMethod]
        public void With_no_overriding_hours_nor_cost_the_populated_hours_and_cost_should_be_same_as_specified_in_type()
        {
            var intervention = engineer.CreateIntervention(client, DateTime.Now, type,
                  null, null, 100, "");

            Assert.AreEqual(type.LabourHours, intervention.HoursRequired);
            Assert.AreEqual(type.MaterialCost, intervention.CostRequired);
        }

        [TestMethod]
        public void With_overriding_hours_but_not_overridding_cost_the_populated_cost_should_be_same_as_specified_in_type()
        {
            var intervention= engineer.CreateIntervention(client, DateTime.Now, type,
                40, null, 100, "");

            Assert.AreEqual(40, intervention.HoursRequired);
            Assert.AreEqual(type.MaterialCost, intervention.CostRequired);
        }

        [TestMethod]
        public void With_no_overriding_hours_but_overridding_cost_the_populated_hours_cost_should_be_same_as_specified_in_type()
        {
            var intervention = engineer.CreateIntervention(client, DateTime.Now, type,
                null, 400, 100, "");

            Assert.AreEqual(type.LabourHours, intervention.HoursRequired);
            Assert.AreEqual(400, intervention.CostRequired);
        }

        [TestMethod]
        public void With_overriding_hours_nor_cost_the_populated_hours_and_cost_should_be_same_as_specified_in_type()
        {
            var intervention = engineer.CreateIntervention(client, DateTime.Now, type,
                40, 400, 100, "");

            Assert.AreEqual(40, intervention.HoursRequired);
            Assert.AreEqual(400, intervention.CostRequired);
        }
    }
}
