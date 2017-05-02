using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterventionMonitor.DataAccess
{
    public class Reports
    {
        SqlConnection connection = DatabaseConnections.DataConnection;
        string queryString = "";

        public string TotalEngineerCost(string engineerID)
        {
            string result = "";
            queryString = "SELECT SUM(MaterialCost) AS TotalCost FROM Intervention WHERE SiteEngineerId ='" + engineerID + "'";
            SqlCommand comm = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                result = reader[0].ToString();

            }
            connection.Close();

            return result;
        }

        public string AverageEngineerCost(string engineerID)
        {
            string result = "";
            queryString = "SELECT AVG(MaterialCost) AS TotalCost FROM Intervention WHERE SiteEngineerId ='" + engineerID + "'";
            SqlCommand comm = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                result = reader[0].ToString();
            }
            connection.Close();
            return result;
        }

        public string TotalDistrictCost(string districtID)
        {
            string result = "";
            queryString = "SELECT SUM(MaterialCost) AS TotalCost FROM Intervention INNER JOIN Client ON Client.Id = Intervention.ClientId  WHERE Client.DistrictId ='" + districtID + "'";
            SqlCommand comm = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                result = reader[0].ToString();
            }
            connection.Close();
            return result;
        }

    }
}