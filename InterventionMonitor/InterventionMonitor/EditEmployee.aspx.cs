﻿using InterventionMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionMonitor
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string districtID = "";
                SqlConnection connection = DatabaseConnections.DataConnection;
                string queryString = "SELECT * FROM Employee INNER JOIN SiteEngineer ON Employee.Id = SiteEngineer.EmployeeId WHERE EmployeeId = '" + Session["EmployeeID"].ToString() + "'";

                SqlCommand comm = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = comm.ExecuteReader();
                lblDisplayEmployeeID.Text = Session["EmployeeID"].ToString();
                while (reader.Read())
                {
                    lblDisplayEmployeeName.Text = reader["Name"].ToString();
                    lblDisplayEmployeeUserName.Text = reader["Username"].ToString();
                    districtID = reader["DistrictID"].ToString();
                }

                connection.Close();


                string queryString2 = "SELECT * FROM District";
                SqlCommand comm2 = new SqlCommand(queryString2, connection);
                connection.Open();
                SqlDataReader reader2 = comm2.ExecuteReader();

                ddlDistrict.DataSource = reader2;
                ddlDistrict.DataTextField = "Name";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.SelectedValue = districtID;
                connection.Close();

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = DatabaseConnections.DataConnection;
            string query = "UPDATE SiteEngineer SET DistrictId = '" + ddlDistrict.SelectedValue.ToString() + "' WHERE EmployeeId = '" + Session["EmployeeId"] + "'"; 
            SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@DistrictID", ddlDistrict.SelectedValue);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            connection.Close();
            string query2 = "UPDATE Manager SET DistrictId = '" + ddlDistrict.SelectedValue.ToString() + "' WHERE EmployeeId = '" + Session["EmployeeId"] + "'";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            connection.Open();
            SqlDataReader reader2 = cmd.ExecuteReader();
            connection.Close();
        }
    }
}