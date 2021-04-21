using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HBPOS.Data;
using JMT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace JMT.Controllers
{
    public class CustomerInfoController : Controller
    {
		public static db dbObj = new db();
		string con2 = dbObj.getConString();

		[HttpPost]
		[Route("api/InserNewCustomer")]
		public List<Response> InsertDeveloper([FromBody] CustInsert data)
		{
			
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("InsertNewCustomer", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FirstName", data.FirstName);
			cmd.Parameters.AddWithValue("@LastName", data.LastName);
			cmd.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
			cmd.Parameters.AddWithValue("@Email", data.Email);
			cmd.Parameters.AddWithValue("@Password", data.Password);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/getCustomerInfo/{Email}/{Password}")]
		public List<CustomerInfo> GetCustomerInfo(string Email = "", string Password = "")
		{
			List<CustomerInfo> customer = new List<CustomerInfo>();
			using (SqlConnection con = new SqlConnection(con2))
			{
				SqlCommand cmd = new SqlCommand("GetCustomerInfo", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Email", Email);
				cmd.Parameters.AddWithValue("@Password", Password);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					CustomerInfo finalcustomer = new CustomerInfo();
					finalcustomer.CustomerID = (Convert.ToInt32(rdr["CustomerID"]));
					finalcustomer.FirstName = (rdr["FirstName"].ToString());
					finalcustomer.LastName = (rdr["LastName"].ToString());
					finalcustomer.PhoneNumber = (rdr["PhoneNumber"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Password = (rdr["Password"].ToString());
					finalcustomer.RoleDesc = (rdr["RoleDesc"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.SideBarColor = (rdr["SideBarColor"].ToString());
					finalcustomer.DashboardColor = (rdr["DashboardColor"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		[HttpGet]
		[Route("api/getCustomerInfoByID/{ID}")]
		public List<CustomerInfo> GetCustomerInfobyID(string ID = "")
		{
			List<CustomerInfo> customer = new List<CustomerInfo>();
			using (SqlConnection con = new SqlConnection(con2))
			{
				SqlCommand cmd = new SqlCommand("GetCustomerInfoByID", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ID", ID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					CustomerInfo finalcustomer = new CustomerInfo();
					finalcustomer.CustomerID = (Convert.ToInt32(rdr["CustomerID"]));
					finalcustomer.FirstName = (rdr["FirstName"].ToString());
					finalcustomer.LastName = (rdr["LastName"].ToString());
					finalcustomer.PhoneNumber = (rdr["PhoneNumber"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Password = (rdr["Password"].ToString());
					finalcustomer.RoleDesc = (rdr["RoleDesc"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.SideBarColor = (rdr["SideBarColor"].ToString());
					finalcustomer.DashboardColor = (rdr["DashboardColor"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		[HttpPost]
		[Route("api/UpdateCustomerInfo")]
		public List<Response> UpdateCustomerInfo([FromBody] CustUpdate data)
		{
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateCustomerInfo", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CustomerID", data.CustomerID);
			cmd.Parameters.AddWithValue("@FirstName", data.FirstName);
			cmd.Parameters.AddWithValue("@LastName", data.LastName);
			cmd.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
			cmd.Parameters.AddWithValue("@Email", data.Email);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/GetProfileImageCustomer/{Email}")]
		public String GetCustImage(string Email = "")
		{
			object result = "";
			string finalresult = "";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("SELECT Photo From TCustomers Where Email = '" + Email + "'", con);
			con.Open();
			result = cmd.ExecuteScalar();
			finalresult = result.ToString();
			con.Close();
			return finalresult;
		}
	}
}
