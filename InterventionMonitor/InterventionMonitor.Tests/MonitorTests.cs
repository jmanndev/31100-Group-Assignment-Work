using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterventionMonitor.Models;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class MonitorTests
    {
        /**
        Copy paste from "Test Cases.txt" by George (uploaded on Facebook group):
        Test cases based on scenario:
        Alice = Site engineer
        Josia = client

        - Alice successfuly logs in as site engineer.
        - New client is created with name "Josiah".
        - mosquito net intervention is created for "Josiah".
        - An intervention is waiting for approval where cost is greater than SE approval limit.
        - Alice is able to retrieve the list of interventions for a client.
        - Mosquito net for Josiah is lost so the effective life is 0%.
        - site engineer cannot create intervention for client in different district.
        - District manager is able to modify administrative information for intervention.
        - Site engineer who created the intervention can modify administrative information.
        - A different site engineer from the district can update the expected life of an intervention.
        - Intervention statis is locked in cancelled state.
        - Intervention statis is locked in completed state.
        - Intervention status cannot change directly form Proposed to Completed.
        - Accountant can view the total cost incurred by a site engineer.
        - Accountant can view the average cost incurred by a site engineer.
        - Accountant can view the total cost for a district.
        - Accountant can view the monthly cost of a district.
             
         */

        [TestClass]
        public class DistrictTest
        {
            [TestMethod]
            public void Equals_ComparesName()
            {
                Assert.AreEqual(Districts.Instance.UrbanIndonesia, Districts.Instance.UrbanIndonesia);
                Assert.AreNotEqual(Districts.Instance.RuralIndonesia, Districts.Instance.Sydney);
            }
        }

        [TestClass]
        public class SiteEngineerTest
        {
            SiteEngineer siteEngineer;

            [TestInitialize]
            public void Setup()
            {
                siteEngineer = new SiteEngineer();
            }

            [TestMethod]
            public void CreateClient_WithNonNullName_AddsExtraClient()
            {
                var previousCount = Monitor.Instance.clients.Count;
                siteEngineer.CreateClient("payless shoes");

                int expectedCount = previousCount + 1;
                Assert.AreEqual(expectedCount, Monitor.Instance.clients.Count);
            }

            [TestMethod]
            public void CreateClient_WithNullName_AddsNoClient()
            {
                var previousCount = Monitor.Instance.clients.Count;
                siteEngineer.CreateClient(null);
                
                Assert.AreEqual(previousCount, Monitor.Instance.clients.Count);
            }
        }
    }
}
