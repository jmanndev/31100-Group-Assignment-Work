using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using InterventionMonitor.DataAccess;
using Microsoft.AspNet.Identity;

namespace InterventionMonitor.Models
{
    public class Employee
    {
        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
    }
}