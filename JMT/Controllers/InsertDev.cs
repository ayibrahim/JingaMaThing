using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HBPOS.Data;
using JMT.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers {

	//Mark As Done
	public class InsertDev : Controller {
		public static db dbObj = new db();
		string con2 = dbObj.getConString();
		[HttpPost]
		[Route("api/InsertNewTask")]
		public List<Response> InsertNewTask([FromBody]NewTask data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("InsertNewTask", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@OrderID", data.OrderID);
			cmd.Parameters.AddWithValue("@DeveloperID", data.DeveloperID);
			cmd.Parameters.AddWithValue("@Description", data.Description);
			cmd.Parameters.AddWithValue("@Title", data.Title);
			cmd.Parameters.AddWithValue("@Notes", data.Notes);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}



		[HttpPost]
		[Route("api/UpdateTask")]
		public List<Response> UpdateTask([FromBody]UpdateTask data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateTask", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperTaskID", data.DeveloperTaskID);
			cmd.Parameters.AddWithValue("@Title", data.Title);
			cmd.Parameters.AddWithValue("@Description", data.Description);
			cmd.Parameters.AddWithValue("@Notes", data.Notes);
			cmd.Parameters.AddWithValue("@Status", data.Status);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpPost]
		[Route("api/UpdateOrderComplete")]
		public List<Response> UpdateOrderComplete([FromBody]UpdateOrderComplete data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateOrderComplete", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@OrderID", data.OrderID);
			cmd.Parameters.AddWithValue("@Review", data.Review);
			cmd.Parameters.AddWithValue("@Rating", data.Rating);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpPost]
		[Route("api/UpdateRMOpenOrder")]
		public List<Response> UpdateRMOpenOrder([FromBody]UpdateRMOrder data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateRMOpenOrder", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@OrderID", data.OrderNumber);
			cmd.Parameters.AddWithValue("@NewPrice", data.NewPrice);
			cmd.Parameters.AddWithValue("@DateBy", data.DateBy);
			cmd.Parameters.AddWithValue("@Requirements", data.Requirements);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}
		
	}

}