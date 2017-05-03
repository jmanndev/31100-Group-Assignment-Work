using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Manager : Approver
    {
        class DBColumnConstants
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Username = "Username";
            public const string DistrictId = "DistrictId";
            public const string HourApprovalLimit = "HourApprovalLimit";
            public const string CostApprovalLimit = "CostApprovalLimit";
            public const string Notes = "Notes";
        }

        public static class DBQueries
        {
            public static string SelectAll
            {
                get
                {
                    return @"SELECT Id, Name, Username, DistrictId, HourApprovalLimit, CostApprovalLimit, Notes
                        FROM Employee INNER JOIN Manager ON Employee.Id = Manager.EmployeeId";
                }
            }
        }

        public Manager()
        {
        }

        public Manager(SqlDataReader reader)
        {
            Id = reader[DBColumnConstants.Id].ToString();
            Name = reader[DBColumnConstants.Name].ToString();
            UserName = reader[DBColumnConstants.Username].ToString();
            var districtId = (int)reader[DBColumnConstants.DistrictId];
            District = Districts.Instance.FindDistrict(districtId);
            HourLimit = (decimal)reader[DBColumnConstants.HourApprovalLimit];
            CostLimit = (decimal)reader[DBColumnConstants.CostApprovalLimit];
            Notes = reader[DBColumnConstants.Notes].ToString();
        }
    }
}