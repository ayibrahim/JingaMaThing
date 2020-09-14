using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using JMT.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers {
	[Produces("application/json")]
	//Mark As Done
	public class InboxController : Controller {
		string con2 = "Server = DESKTOP-PBEU3TN;Database=JMT;Trusted_Connection=True";
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
		[Route("api/SendForgotPasswordEmail/{Email}")]
		public List<Response> SendForgotPasswordEmail(string Email = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Found";
			string password = "";
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetUserPasswordFromEmail", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Email", Email);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					password = (rdr["Password"].ToString());
				}
				con.Close();
			}
				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
				//%[za$Bhm+~FJZXm6EW-]~T
				mail.From = new MailAddress("jmtithelpdesk@gmail.com");
				mail.To.Add(Email);
				mail.Subject = "JMT Password Reset";
				mail.Body = "This email was sent to you because someone submitted a forgot password request for this email."+ Environment.NewLine + Environment.NewLine +
				   "Your Password is : " + password.ToString() + Environment.NewLine + Environment.NewLine +
					"To reset your password visit our home page sign in and click on reset password." + Environment.NewLine + Environment.NewLine +
					" If this was not you please contact jmtithelpdesk@gmail.com , Thank You.";

				SmtpServer.Port = 587;
				SmtpServer.Credentials = new System.Net.NetworkCredential("jmtithelpdesk@gmail.com", "%[za$Bhm+~FJZXm6EW-]~T");
				SmtpServer.EnableSsl = true;

				SmtpServer.Send(mail);
				finalresult.response = result.ToString();
				Customer.Add(finalresult);
				return Customer;

		}

		[HttpPost]
		[Route("api/UpdateResetPassword")]
		public List<Response> UpdateResetPassword([FromBody]ResetPassword data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateResetPassword", con);
			cmd.CommandType = CommandType.StoredProcedure;
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
		[Route("api/CheckEmailPasswordExist/{Email}/{Password}")]
		public List<Response> GetUserPasswordFromEmail(string Email = "" , string Password = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Found";
			string result2 = "NotFound";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("CheckEmailPasswordExist", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Email", Email);
			cmd.Parameters.AddWithValue("@Password", Password);
			con.Open();
			object i = cmd.ExecuteScalar();
			con.Close();
			int i2 = Convert.ToInt32(i);
			if (i2 == 1) {
				finalresult.response = result.ToString();
				Customer.Add(finalresult);
			}
			else {
				finalresult.response = result2.ToString();
				Customer.Add(finalresult);
			}
			return Customer;
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