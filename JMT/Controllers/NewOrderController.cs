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

	public class NewOrderController : Controller
    {
		string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";
		[HttpGet]
		[Route("api/GetListofDevs")]
		public List<DevList> GetDevList() {
			
			List<DevList> devlist = new List<DevList>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevListBox_Customer", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevList finalcustomer = new DevList();
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		

		[HttpPost]
		[Route("api/InsertNewOrder")]
		public List<Response> InsertNewOrder([FromBody]InsertNewOrder data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("InsertNewOrder", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CustomerID", data.CustomerID);
			cmd.Parameters.AddWithValue("@DevEmail", data.DevEmail);
			cmd.Parameters.AddWithValue("@OrderDesc", data.OrderDesc);
			cmd.Parameters.AddWithValue("@OrderRequirments", data.OrderRequirments);
			cmd.Parameters.AddWithValue("@Budget", data.Budget);
			cmd.Parameters.AddWithValue("@DateBy", data.DateBy);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/GetDevPendingOrders/{DeveloperID}")]
		public List<DevPendingOrder> GetDevPendingOrders(string DeveloperID = "") {

			List<DevPendingOrder> devlist = new List<DevPendingOrder>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevPendingOrders", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevPendingOrder finalcustomer = new DevPendingOrder();
					finalcustomer.DeveloperPendingID = Convert.ToInt32(rdr["DeveloperPendingID"]);
					finalcustomer.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
					finalcustomer.DeveloperID = Convert.ToInt32(rdr["DeveloperID"]);
					finalcustomer.OrderDesc = (rdr["OrderDesc"].ToString());
					finalcustomer.DateRequested = (rdr["DateRequested"].ToString());
					finalcustomer.Budget = (rdr["Budget"].ToString());
					finalcustomer.Requirements = (rdr["Requirements"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		[HttpGet]
		[Route("api/GetCustomerPendingApproval/{CustomerID}")]
		public List<CustomerApproval> GetCustomerPendingApproval(string CustomerID = "") {

			List<CustomerApproval> devlist = new List<CustomerApproval>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetCustomerPendingApproval", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					CustomerApproval finalcustomer = new CustomerApproval();
					finalcustomer.CustomerPendingID = Convert.ToInt32(rdr["CustomerPendingID"]);
					finalcustomer.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
					finalcustomer.DeveloperID = Convert.ToInt32(rdr["DeveloperID"]);
					finalcustomer.OrderDesc = (rdr["OrderDesc"].ToString());
					finalcustomer.DateOffered = (rdr["DateOffered"].ToString());
					finalcustomer.PriceOffered = (rdr["PriceOffered"].ToString());
					finalcustomer.Requirements = (rdr["Requirements"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}


		[HttpGet]
		[Route("api/GetCustomerPendingOrders/{CustomerID}")]
		public List<CustomerPendingO> GetCustomerPendingOrders(string CustomerID = "") {

			List<CustomerPendingO> devlist = new List<CustomerPendingO>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetCustomerPendingOrders", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					CustomerPendingO finalcustomer = new CustomerPendingO();
					finalcustomer.DeveloperPendingID = Convert.ToInt32(rdr["DeveloperPendingID"]);
					finalcustomer.Description = (rdr["Description"].ToString());
					finalcustomer.Desired_Completion_Date = (rdr["Desired_Completion_Date"].ToString());
					finalcustomer.DateCreated = (rdr["DateCreated"].ToString());
					finalcustomer.Budget = (rdr["Budget"].ToString());
					finalcustomer.Requirements = (rdr["Requirements"].ToString());
					finalcustomer.Name = (rdr["Name"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		[HttpGet]
		[Route("api/GetDevPendingCustomerOrders/{DeveloperID}")]
		public List<DevPendingCustomerApproval> GetDevPendingCustomerOrders(string DeveloperID = "") {

			List<DevPendingCustomerApproval> devlist = new List<DevPendingCustomerApproval>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevPendingCustomerOrders", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevPendingCustomerApproval finalcustomer = new DevPendingCustomerApproval();
					finalcustomer.CustomerPendingID = Convert.ToInt32(rdr["CustomerPendingID"]);
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Description = (rdr["Description"].ToString());
					finalcustomer.PriceOffered = (rdr["PriceOffered"].ToString());
					finalcustomer.Requirements = (rdr["Requirements"].ToString());
					finalcustomer.DateOffered = (rdr["DateOffered"].ToString());
					finalcustomer.DateAccepted = (rdr["DateAccepted"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		[HttpGet]
		[Route("api/UpdateDevOrder/{DeveloperPendingID}/{DeclineReason}")]
		public List<Response> InsertOrder(string DeveloperPendingID = "", string DeclineReason = "") {
			Response finalresult = new Response();
			List<Response> Order = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateOrderDeclined", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperPendingID", DeveloperPendingID);
			cmd.Parameters.AddWithValue("@DeclineReason", DeclineReason);
			con.Open();
			int i = cmd.ExecuteNonQuery();

			con.Close();
			finalresult.response = result.ToString();
			Order.Add(finalresult);
			return Order;
		}

		[HttpGet]
		[Route("api/UpdateCustomerDeclined/{CustomerPendingID}")]
		public List<Response> UpdateCustomerDeclined(string CustomerPendingID = "") {
			Response finalresult = new Response();
			List<Response> Order = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateCustomerDeclined", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CustomerPendingID", CustomerPendingID);
			con.Open();
			int i = cmd.ExecuteNonQuery();

			con.Close();
			finalresult.response = result.ToString();
			Order.Add(finalresult);
			return Order;
		}

		[HttpPost]
		[Route("api/InsertNewOrderDevCustomerApproved")]
		public List<Response> InsertNewOrderDevCustomerApproved([FromBody]DevCustomerApproved data) {
			Response finalresult = new Response();
			List<Response> Order = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("InsertNewOrderDevCustomerApproved", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CustomerPendingID", data.CustomerPendingID);
			cmd.Parameters.AddWithValue("@CustomerID", data.CustomerID);
			cmd.Parameters.AddWithValue("@DeveloperID", data.DeveloperID);
			cmd.Parameters.AddWithValue("@Price", data.Price);
			cmd.Parameters.AddWithValue("@CompletionDate", data.CompletionDate);
			cmd.Parameters.AddWithValue("@OrderDesc", data.OrderDesc);
			cmd.Parameters.AddWithValue("@Requirements", data.Requirements);
			con.Open();
			int i = cmd.ExecuteNonQuery();

			con.Close();
			finalresult.response = result.ToString();
			Order.Add(finalresult);
			return Order;
		}

		[HttpGet]
		[Route("api/AcceptDevOrder/{DeveloperPendingID}/{PriceOffered}/{DateOffered}")]
		public List<Response> AcceptOrder(string DeveloperPendingID = "", string PriceOffered = "" , string DateOffered = "") {
			Response finalresult = new Response();
			List<Response> Order = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateOrderAccepted_Dev", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperPendingID", DeveloperPendingID);
			cmd.Parameters.AddWithValue("@PriceOffered", PriceOffered);
			cmd.Parameters.AddWithValue("@DateOffered", DateOffered);
			con.Open();
			int i = cmd.ExecuteNonQuery();

			con.Close();
			finalresult.response = result.ToString();
			Order.Add(finalresult);
			return Order;
		}

		[HttpGet]
		[Route("api/GetCustomerPendingDeclined/{CustomerID}")]
		public List<CustomerPendingDeclined> GetCustomerPendingDeclined(string CustomerID = "") {

			List<CustomerPendingDeclined> devlist = new List<CustomerPendingDeclined>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetCustomerPendingDeclined", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					CustomerPendingDeclined finalcustomer = new CustomerPendingDeclined();
					finalcustomer.DeveloperDeclinedID = Convert.ToInt32(rdr["DeveloperDeclinedID"]);
					finalcustomer.DeveloperName = (rdr["DeveloperName"].ToString());
					finalcustomer.OrderDescription = (rdr["OrderDescription"].ToString());
					finalcustomer.DeclineReason = (rdr["DeclineReason"].ToString());
					finalcustomer.DeclinedDate = (rdr["DeclinedDate"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}
	}
}