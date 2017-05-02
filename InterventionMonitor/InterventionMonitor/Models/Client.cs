﻿using InterventionMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Client : ITestableValidModel
    {
        class DBColumnConstants
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string DistrictId = "DistrictID";
            public const string Address = "Address";
            public const string Notes = "Notes";
        }

        public static class DBQueries
        {
            public static string SelectAll
            {
                get
                {
                    return "SELECT Id, Name, DistrictId, Address, Notes FROM Client";
                }
            }
        }

        [Key]
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public District District
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public Client()
        {
        }

        public Client(SqlDataReader reader)
        {
            ID = (int)reader[DBColumnConstants.Id];
            Name = reader[DBColumnConstants.Name].ToString();
            var districtId = (int)reader[DBColumnConstants.DistrictId];
            District = Districts.Instance.FindDistrict(districtId);
            Address = reader[DBColumnConstants.Address].ToString();
            Notes = reader[DBColumnConstants.Notes].ToString();
        }

        public Client(string name, string address, District district)
        {
            Name = name;
            Address = address;
            District = district;
          
            AddClientToDB();
        }

        void AddClientToDB()
        {
#if DEBUG
            if (!UnitTestDetector.IsInUnitTest)
#endif
            {
                SqlConnection connection = DatabaseConnections.GetDataConnection();
                string query = "INSERT INTO Client (Name, DistrictID, Address) VALUES (@Name, @DistrictID, @Address)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DistrictID", District.ID);
                cmd.Parameters.AddWithValue("@Address", Address);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                connection.Close();
            }
        }

        public void FillInValidTestData()
        {
            Name = "Jenny";
            District = Districts.Instance.Sydney;
        }
    }
}