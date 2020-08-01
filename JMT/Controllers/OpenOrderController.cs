﻿using System;
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

	public class OpenOrderController : Controller
    {
		string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";
		[HttpGet]	
		[Route("api/GetDevOpenOrders/{DeveloperID}")]
		public List<DevOpenOrder> GetDevOpenOrders(string DeveloperID = "") {
			
			List<DevOpenOrder> devlist = new List<DevOpenOrder>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevOpenOrders", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevOpenOrder finalcustomer = new DevOpenOrder();
					finalcustomer.OrderNumber = Convert.ToInt32(rdr["OrderNumber"]);
					finalcustomer.DeveloperID = Convert.ToInt32(rdr["DeveloperID"]);
					finalcustomer.CustomerName = (rdr["CustomerName"].ToString());
					finalcustomer.Description = (rdr["Description"].ToString());
					finalcustomer.Requirements = (rdr["Requirements"].ToString());
					finalcustomer.CompletionDate = (rdr["CompletionDate"].ToString());
					finalcustomer.Status = (rdr["Status"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		[HttpGet]
		[Route("api/GetOrderTasks/{OrderID}")]
		public List<Tasks> GetOrderTasks(string OrderID = "") {

			List<Tasks> devlist = new List<Tasks>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetOrderTasks", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@OrderID", OrderID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					Tasks finalcustomer = new Tasks();
					finalcustomer.DeveloperTaskID = Convert.ToInt32(rdr["DeveloperTaskID"]);
					finalcustomer.OrderNumber = Convert.ToInt32(rdr["OrderNumber"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.Description = (rdr["Description"].ToString());
					finalcustomer.Notes = (rdr["Notes"].ToString());
					finalcustomer.Status = (rdr["Status"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}

		
		[HttpGet]
		[Route("api/DeleteTask/{DeveloperTaskID}")]
		public List<Response> DeleteTask(string DeveloperTaskID = "") {
			Response finalresult = new Response();
			List<Response> Order = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("DeleteTask", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperTaskID", DeveloperTaskID);
			con.Open();
			int i = cmd.ExecuteNonQuery();

			con.Close();
			finalresult.response = result.ToString();
			Order.Add(finalresult);
			return Order;
		}

		[HttpGet]
		[Route("api/UpdateDevOrder/{OrderID}")]
		public List<Response> UpdateDevOrder(string OrderID = "") {
			Response finalresult = new Response();
			List<Response> Order = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateDevOrder", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@OrderID", OrderID);
			con.Open();
			int i = cmd.ExecuteNonQuery();

			con.Close();
			finalresult.response = result.ToString();
			Order.Add(finalresult);
			return Order;
		}

	}
}