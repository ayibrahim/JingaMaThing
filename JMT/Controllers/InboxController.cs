using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JMT.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers {
	[Produces("application/json")]

	public class InboxController : Controller {
		string testing2 = "";
		private IHostingEnvironment _hostingEnvironment;
		string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";
		public InboxController(IHostingEnvironment hostingEnvironment) {
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpGet]
		[Route("api/GetCustomerInbox/{CustomerID}")]
		public List<Inbox> GetCustomerInfo(string CustomerID = "") {
			
			List<Inbox> customer = new List<Inbox>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetCustomerInbox", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					Inbox finalcustomer = new Inbox();
					finalcustomer.ID = (Convert.ToInt32(rdr["ID"]));
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.RecievedDate = (rdr["RecievedDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			
			return customer;
		}
		[HttpGet]
		[Route("api/GetDeveloperInbox/{DeveloperID}")]
		public List<Inbox> GetDeveloperID(string DeveloperID = "") {
			
			List<Inbox> customer = new List<Inbox>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDeveloperInbox", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					Inbox finalcustomer = new Inbox();
					finalcustomer.ID = (Convert.ToInt32(rdr["ID"]));
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.RecievedDate = (rdr["RecievedDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}
		[HttpGet]
		[Route("api/GetRMInbox/{ResourceManagerID}")]
		public List<Inbox> GetResourceMangerInbox(string ResourceManagerID = "") {
			
			List<Inbox> customer = new List<Inbox>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetRMInbox", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					Inbox finalcustomer = new Inbox();
					finalcustomer.ID = (Convert.ToInt32(rdr["ID"]));
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.RecievedDate = (rdr["RecievedDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}
		[HttpGet]
		[Route("api/GetDevRMList")]
		public List<DevRMList> GetDevRMList() {
			
			List<DevRMList> customer = new List<DevRMList>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevRMListBox_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevRMList finalcustomer = new DevRMList();
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevRMListBox_Dev", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevRMList finalcustomer = new DevRMList();
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}


		[HttpPost]
		[Route("api/SendMessage")]
		public List<Response> InsertDeveloper([FromBody]SendMessage data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("SendMessage", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@RoleDesc", data.RoleDesc);
			cmd.Parameters.AddWithValue("@Email", data.Email);
			cmd.Parameters.AddWithValue("@Title", data.Title);
			cmd.Parameters.AddWithValue("@Description", data.Description);
			cmd.Parameters.AddWithValue("@EmailTo", data.EmailTo);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/GetDevRMCustomerList")]
		public List<DevRMList> GetDevRMCustomerList() {
			
			List<DevRMList> customer = new List<DevRMList>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevRMListBox_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevRMList finalcustomer = new DevRMList();
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevRMListBox_Dev", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevRMList finalcustomer = new DevRMList();
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevRMListBox_Customer", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevRMList finalcustomer = new DevRMList();
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		
		[HttpGet]
		[Route("api/GetCustomerInboxSent/{CustomerID}")]
		public List<InboxSent> GetCustomerInboxSent(string CustomerID = "") {

			List<InboxSent> customer = new List<InboxSent>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetCustomerSentMessages", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
				cmd.Parameters.AddWithValue("@Number", 1);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					InboxSent finalcustomer = new InboxSent();
					finalcustomer.ID = (rdr["ID"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.SentDate = (rdr["SentDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetCustomerSentMessages", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
				cmd.Parameters.AddWithValue("@Number", 2);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					InboxSent finalcustomer = new InboxSent();
					finalcustomer.ID = (rdr["ID"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.SentDate = (rdr["SentDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		[HttpGet]
		[Route("api/GetDeveloperInboxSent/{DeveloperID}")]
		public List<InboxSent> GetDeveloperSentInbox(string DeveloperID = "") {

			List<InboxSent> customer = new List<InboxSent>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevSentMessages", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				cmd.Parameters.AddWithValue("@Number", 1);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					InboxSent finalcustomer = new InboxSent();
					finalcustomer.ID = (rdr["ID"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.SentDate = (rdr["SentDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevSentMessages", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				cmd.Parameters.AddWithValue("@Number", 2);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					InboxSent finalcustomer = new InboxSent();
					finalcustomer.ID = (rdr["ID"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.SentDate = (rdr["SentDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevSentMessages", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				cmd.Parameters.AddWithValue("@Number", 3);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					InboxSent finalcustomer = new InboxSent();
					finalcustomer.ID = (rdr["ID"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.SentDate = (rdr["SentDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		[HttpGet]
		[Route("api/GetRMSentMessages/{ResourceManagerID}")]
		public List<InboxSent> GetRMSentMessages(string ResourceManagerID = "") {

			List<InboxSent> customer = new List<InboxSent>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetRMSentMessages", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				cmd.Parameters.AddWithValue("@Number", 1);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					InboxSent finalcustomer = new InboxSent();
					finalcustomer.ID = (rdr["ID"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.SentDate = (rdr["SentDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetRMSentMessages", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				cmd.Parameters.AddWithValue("@Number", 2);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					InboxSent finalcustomer = new InboxSent();
					finalcustomer.ID = (rdr["ID"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.SentDate = (rdr["SentDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetRMSentMessages", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				cmd.Parameters.AddWithValue("@Number", 3);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					InboxSent finalcustomer = new InboxSent();
					finalcustomer.ID = (rdr["ID"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Subject = (rdr["Subject"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
					finalcustomer.SentDate = (rdr["SentDate"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}
	}

}