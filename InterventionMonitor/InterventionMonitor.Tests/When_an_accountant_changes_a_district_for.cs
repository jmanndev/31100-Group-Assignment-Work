using System;
using InterventionMonitor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterventionMonitor.Tests
{
    [TestClass]
    public class When_an_accountant_changes_a_district_for
    {
        Accountant accountant;
        SiteEngineer siteEngineer;
        Manager manager;

        [TestInitialize]
        public void Setup()
        {
            accountant = new Accountant();

            siteEngineer = new SiteEngineer();
            siteEngineer.District = Districts.Instance.RuralIndonesia;

            manager = new Manager();
            manager.District = Districts.Instance.RuralIndonesia;

        }

        [TestMethod]
        public void A_site_engineer_then_update_the_engineers_district_and_match_new_district()
        {
            accountant.ChangeEngineerDistrict(siteEngineer, Districts.Instance.Sydney);

            //Checks to see if the site engineers district was changed successfully
            Assert.AreEqual(Districts.Instance.Sydney, siteEngineer.District);
        }

        [TestMethod]
        public void A_manager_then_update_the_managers_district_and_match_new_district()
        {
            accountant.ChangeManagerDistrict(manager, Districts.Instance.Sydney);

            //Chcks to see if the managers district was changed successfully
            Assert.AreEqual(Districts.Instance.Sydney, manager.District);
        }
    }
}
