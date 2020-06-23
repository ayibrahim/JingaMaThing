using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JMT.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers
{
    [Produces("application/json")]
   
    public class InboxController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public InboxController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("api/GetCustomerInbox/{CustomerID}")]
        public List<Inbox> GetCustomerInfo(string CustomerID = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            List<Inbox> customer = new List<Inbox>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetCustomerInbox", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Inbox finalcustomer = new Inbox();
                    finalcustomer.Name = (rdr["Name"].ToString());
                    finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
                    finalcustomer.RecievedDate = (rdr["RecievedDate"].ToString());
                    customer.Add(finalcustomer);
                }
            }
            return customer;
        }
        [HttpGet]
        [Route("api/GetDeveloperInbox/{DeveloperID}")]
        public List<Inbox> GetDeveloperID(string DeveloperID = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            List<Inbox> customer = new List<Inbox>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetDeveloperInbox", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Inbox finalcustomer = new Inbox();
                    finalcustomer.Name = (rdr["Name"].ToString());
                    finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
                    finalcustomer.RecievedDate = (rdr["RecievedDate"].ToString());
                    customer.Add(finalcustomer);
                }
            }
            return customer;
        }
        [HttpGet]
        [Route("api/GetRMInbox/{@ResourceManagerID}")]
        public List<Inbox> GetResourceMangerInbox(string ResourceManagerID = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            List<Inbox> customer = new List<Inbox>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetRMInbox", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Inbox finalcustomer = new Inbox();
                    finalcustomer.Name = (rdr["Name"].ToString());
                    finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.Message = (rdr["Message"].ToString());
                    finalcustomer.RecievedDate = (rdr["RecievedDate"].ToString());
                    customer.Add(finalcustomer);
                }
            }
            return customer;
        }
		[HttpGet]
		[Route("api/GetDevRMList")]
		public List<DevRMList> GetDevRMList() {
			string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		[HttpGet]
		[Route("api/SendCustomerMessage/{RoleDesc}/{Email}/{Title}/{Description}/{EmailTo}")]
		public List<Response> SendCustomerMessage(string RoleDesc = "", string Email = "", string Title = "", string Description = "", string EmailTo = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("SendCustomerMessage", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@RoleDesc", RoleDesc);
			cmd.Parameters.AddWithValue("@Email", Email);
			cmd.Parameters.AddWithValue("@Title", Title);
			cmd.Parameters.AddWithValue("@Description", Description);
			cmd.Parameters.AddWithValue("@EmailTo", EmailTo);
			con.Open();
			int i = cmd.ExecuteNonQuery();

			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}
	}
}