using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JMT.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers {
	
	
	public class LinksController : Controller {
		string con2 = "Server = DESKTOP-PBEU3TN;Database=JMT;Trusted_Connection=True";
		[HttpPost]
		[Route("api/CreateDevLink")]
		public List<Response> CreateDevLink([FromBody]CreateDevLink data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("CreateDevLink", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperID", data.DeveloperID);
			cmd.Parameters.AddWithValue("@Title", data.LinkTitle);
			cmd.Parameters.AddWithValue("@HyperLink", data.LinkURL);
			cmd.Parameters.AddWithValue("@ViewType", data.LinkType);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpPost]
		[Route("api/CreateRMLink")]
		public List<Response> CreateDevLink([FromBody]CreateRMLink data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("CreateRMLink", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerID", data.ResourceManagerID);
			cmd.Parameters.AddWithValue("@Title", data.LinkTitle);
			cmd.Parameters.AddWithValue("@HyperLink", data.LinkURL);
			cmd.Parameters.AddWithValue("@ViewType", data.LinkType);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpPost]
		[Route("api/UpdateDevLink")]
		public List<Response> EditDevNoteTitleViewType([FromBody]DevLinks data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateDevLink", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperLinkID", data.DeveloperLinkID);
			cmd.Parameters.AddWithValue("@Title", data.Title);
			cmd.Parameters.AddWithValue("@HyperLink", data.HyperLink);
			cmd.Parameters.AddWithValue("@ViewType", data.ViewType);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpPost]
		[Route("api/UpdateRMLink")]
		public List<Response> UpdateRMLink([FromBody]RMLinks data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateRMLink", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerLinkID", data.ResourceManagerLinkID);
			cmd.Parameters.AddWithValue("@Title", data.Title);
			cmd.Parameters.AddWithValue("@HyperLink", data.HyperLink);
			cmd.Parameters.AddWithValue("@ViewType", data.ViewType);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}
		
		[HttpGet]
		[Route("api/DeleteDevLink/{DeveloperLinkID}")]
		public List<Response> DeleteDevLink(string DeveloperLinkID = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("DeleteDevLink", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperLinkID", DeveloperLinkID);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/DeleteRMLink/{ResourceManagerLinkID}")]
		public List<Response> DeleteRMLink(string ResourceManagerLinkID = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("DeleteRMLink", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerLinkID", ResourceManagerLinkID);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/GetDeveloperLinks/{DeveloperID}")]
		public List<DevLinksData> GetDeveloperLinks(string DeveloperID = "") {

			List<DevLinksData> devlist = new List<DevLinksData>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDeveloperLinks", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevLinksData finalcustomer = new DevLinksData();
					finalcustomer.DeveloperLinkID = Convert.ToInt32(rdr["DeveloperLinkID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.HyperLink = (rdr["HyperLink"].ToString());
					finalcustomer.ViewType = (rdr["ViewType"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		[HttpGet]
		[Route("api/GetRMLinks/{ResourceManagerID}")]
		public List<RMLinkData> GetRMLinks(string ResourceManagerID = "") {

			List<RMLinkData> devlist = new List<RMLinkData>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetRMLinks", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					RMLinkData finalcustomer = new RMLinkData();
					finalcustomer.ResourceManagerLinkID = Convert.ToInt32(rdr["ResourceManagerLinkID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.HyperLink = (rdr["HyperLink"].ToString());
					finalcustomer.ViewType = (rdr["ViewType"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		[HttpGet]
		[Route("api/GetPublicLinksDev/{DeveloperID}")]
		public List<PublicDevLinks> GetDevRMCustomerList(string DeveloperID = "") {

			List<PublicDevLinks> customer = new List<PublicDevLinks>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetPublicLinks_Dev", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				cmd.Parameters.AddWithValue("@Selection", 1);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					PublicDevLinks finalcustomer = new PublicDevLinks();
					finalcustomer.LinkID = Convert.ToInt32(rdr["LinkID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.HyperLink = (rdr["HyperLink"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetPublicLinks_Dev", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				cmd.Parameters.AddWithValue("@Selection", 2);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read()) {
					PublicDevLinks finalcustomer = new PublicDevLinks();
					finalcustomer.LinkID = Convert.ToInt32(rdr["LinkID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.HyperLink = (rdr["HyperLink"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}

			return customer;
		}

		[HttpGet]
		[Route("api/GetPublicLinksRM/{ResourceManagerID}")]
		public List<PublicDevLinks> GetPublicLinksRM(string ResourceManagerID = "") {

			List<PublicDevLinks> customer = new List<PublicDevLinks>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetPublicLinks_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				cmd.Parameters.AddWithValue("@Selection", 1);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					PublicDevLinks finalcustomer = new PublicDevLinks();
					finalcustomer.LinkID = Convert.ToInt32(rdr["LinkID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.HyperLink = (rdr["HyperLink"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetPublicLinks_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				cmd.Parameters.AddWithValue("@Selection", 2);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read()) {
					PublicDevLinks finalcustomer = new PublicDevLinks();
					finalcustomer.LinkID = Convert.ToInt32(rdr["LinkID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.HyperLink = (rdr["HyperLink"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}

			return customer;
		}
		
	}

}