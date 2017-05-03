using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Accountant : Employee
    {

        public void ChangeEngineerDistrict(SiteEngineer siteEngineer, District newDistrict)
        {
            siteEngineer.District = newDistrict;
        }

        public void ChangeManagerDistrict(Manager manager, District newDistrict)
        {
            manager.District = newDistrict;
        }
    }
}