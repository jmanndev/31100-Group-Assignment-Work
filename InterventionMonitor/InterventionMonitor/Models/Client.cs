using InterventionMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class Client
    {
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

        public string DisplayValue
        {
            get
            {
                string result = string.Format("{0}: {1}", ID, Name);
                if (Address.Equals(""))
                    result = string.Format("{0} at {1}", result, Address);
                return result;
            }
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
                SqlConnection connection = DatabaseConnections.DataConnection;
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
    }
}