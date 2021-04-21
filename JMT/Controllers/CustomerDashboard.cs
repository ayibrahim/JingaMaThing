using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HBPOS.Data;
using JMT.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers {
	[Produces("application/json")]
	//Mark As Done
	public class CustomerDashboard : Controller {
		public static db dbObj = new db();
		string con2 = dbObj.getConString();
		[HttpGet]
		[Route("api/GetDevListCustomerDashboard")]
		public List<DevListCustDashboard> GetDeveloperID() {
			
			List<DevListCustDashboard> customer = new List<DevListCustDashboard>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevList_CustomerDashboard", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevListCustDashboard finalcustomer = new DevListCustDashboard();
					finalcustomer.DeveloperID = (Convert.ToInt32(rdr["DeveloperID"]));
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.PLanguages = (rdr["PLanguages"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		[HttpGet]
		[Route("api/GetDevListRMDevelopers/{ResourceManagerID}")]
		public List<DevListCustDashboard> GetDevListRMDevelopers(string ResourceManagerID = "") {

			List<DevListCustDashboard> customer = new List<DevListCustDashboard>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevList_RMDevelopers", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevListCustDashboard finalcustomer = new DevListCustDashboard();
					finalcustomer.DeveloperID = (Convert.ToInt32(rdr["DeveloperID"]));
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.PLanguages = (rdr["PLanguages"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}	
			return customer;
		}

		[HttpGet]
		[Route("api/GetDevNotAssignedToRM/{ResourceManagerID}")]
		public List<DevNotAssignedToRM> GetDevNotAssignedToRM(string ResourceManagerID = "") {

			List<DevNotAssignedToRM> customer = new List<DevNotAssignedToRM>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevNotAssignedToRM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevNotAssignedToRM finalcustomer = new DevNotAssignedToRM();
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.DeveloperID =  Convert.ToInt32(rdr["DeveloperID"]);
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.PLanguages = (rdr["PLanguages"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		[HttpGet]
		[Route("api/AssignDevToRM/{ResourceManagerID}/{DeveloperID}")]
		public List<Response> AssignDevToRM(string ResourceManagerID = "" , string DeveloperID = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("AssignDevToRM", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
			cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);

			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/DevHistoryCustomerReview/{DeveloperID}")]
		public List<DevHistoryCustomerReview> DevHistoryCustomerReview(string DeveloperID = "") {

			List<DevHistoryCustomerReview> devlist = new List<DevHistoryCustomerReview>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("DevHistoryCustomerReview", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);	
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevHistoryCustomerReview finalcustomer = new DevHistoryCustomerReview();
					finalcustomer.OrderNumber = Convert.ToInt32(rdr["OrderNumber"]);
					finalcustomer.Rating = (rdr["Rating"].ToString());
					finalcustomer.CustomerReview = (rdr["CustomerReview"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

	}

}