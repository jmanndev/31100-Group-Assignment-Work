using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
