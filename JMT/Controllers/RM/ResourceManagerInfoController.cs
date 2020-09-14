using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JMT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers
{
    public class ResourceManagerInfoController : Controller
	{
		//Mark As Done
		string con2 = "Server = DESKTOP-PBEU3TN;Database=JMT;Trusted_Connection=True";

		[HttpGet]
		[Route("api/GetResourceManagerInfo/{Email}/{Password}")]
		public List<RMInfo> GetResourceManagerInfo(string Email = "", string Password = "")
		{
			List<RMInfo> customer = new List<RMInfo>();
			using (SqlConnection con = new SqlConnection(con2))
			{
				SqlCommand cmd = new SqlCommand("GetResourceManagerInfo", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Email", Email);
				cmd.Parameters.AddWithValue("@Password", Password);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					RMInfo finalcustomer = new RMInfo();
					finalcustomer.ResourceManagerID = (Convert.ToInt32(rdr["ResourceManagerID"]));
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
		[Route("api/GetResourceManagerInfoByID/{ID}")]
		public List<RMInfo> GetResourceManagerInfoByID(string ID = "")
		{
			List<RMInfo> customer = new List<RMInfo>();
			using (SqlConnection con = new SqlConnection(con2))
			{
				SqlCommand cmd = new SqlCommand("GetResourceManagerInfoByID", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ID", ID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					RMInfo finalcustomer = new RMInfo();
					finalcustomer.ResourceManagerID = (Convert.ToInt32(rdr["ResourceManagerID"]));
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
		[Route("api/UpdateRMInfo")]
		public List<Response> UpdateRMInfo([FromBody] RMUpdate data)
		{
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateRMInfo", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerID", data.ResourceManagerID);
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
		[Route("api/GetProfileImageRManager/{Email}")]
		public String GetProfileImageRManager(string Email = "")
		{
			object result = "";
			string finalresult = "";

			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("SELECT Photo From TResourceManagers Where Email = '" + Email + "'", con);
			con.Open();
			result = cmd.ExecuteScalar();
			finalresult = result.ToString();
			con.Close();
			return finalresult;
		}
	}
}
