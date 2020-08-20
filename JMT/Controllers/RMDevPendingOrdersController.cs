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

	public class RMDevPendingOrdersController : Controller
    {
		string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";
		[HttpGet]
		[Route("api/GetPendingDevResponseRM/{ResourceManagerID}")]
		public List<RMDevPendingList> GetPendingDevResponseRM(string ResourceManagerID = "") {
			
			List<RMDevPendingList> devlist = new List<RMDevPendingList>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetPendingDevResponse_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					RMDevPendingList finalcustomer = new RMDevPendingList();
					finalcustomer.DeveloperPendingID = Convert.ToInt32(rdr["DeveloperPendingID"]);
					finalcustomer.DeveloperName = (rdr["DeveloperName"].ToString());
					finalcustomer.CustomerName = (rdr["CustomerName"].ToString());
					finalcustomer.Description = (rdr["Description"].ToString());
					finalcustomer.Requirements = (rdr["Requirements"].ToString());
					finalcustomer.Budget = (rdr["Budget"].ToString());
					finalcustomer.DateRequested = (rdr["DateRequested"].ToString());
					finalcustomer.CreatedDate = (rdr["CreatedDate"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		[HttpGet]
		[Route("api/GetPendingCustomerResponseRM/{ResourceManagerID}")]
		public List<RMCustPendingList> GetPendingCustomerResponseRM(string ResourceManagerID = "") {

			List<RMCustPendingList> devlist = new List<RMCustPendingList>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetPendingCustomerResponse_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					RMCustPendingList finalcustomer = new RMCustPendingList();
					finalcustomer.CustomerPendingID = Convert.ToInt32(rdr["CustomerPendingID"]);
					finalcustomer.DeveloperName = (rdr["DeveloperName"].ToString());
					finalcustomer.CustomerName = (rdr["CustomerName"].ToString());
					finalcustomer.Description = (rdr["Description"].ToString());
					finalcustomer.Requirements = (rdr["Requirements"].ToString());
					finalcustomer.PriceOffered = (rdr["PriceOffered"].ToString());
					finalcustomer.DateOffered = (rdr["DateOffered"].ToString());
					finalcustomer.DevAcceptedDate = (rdr["DevAcceptedDate"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		[HttpGet]
		[Route("api/GetDevOrderHistoryRM/{ResourceManagerID}")]
		public List<RMDevOrderHistory> GetDevOrderHistoryRM(string ResourceManagerID = "") {

			List<RMDevOrderHistory> devlist = new List<RMDevOrderHistory>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevOrderHistory_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					RMDevOrderHistory finalcustomer = new RMDevOrderHistory();
					finalcustomer.OrderNumber = Convert.ToInt32(rdr["OrderNumber"]);
					finalcustomer.DeveloperName = (rdr["DeveloperName"].ToString());
					finalcustomer.CustomerName = (rdr["CustomerName"].ToString());
					finalcustomer.Description = (rdr["Description"].ToString());
					finalcustomer.Requirements = (rdr["Requirements"].ToString());
					finalcustomer.CompletionDate = (rdr["CompletionDate"].ToString());
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