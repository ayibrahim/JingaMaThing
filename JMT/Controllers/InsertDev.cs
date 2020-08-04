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
	
	
	public class InsertDev : Controller {
		string testing2 = "";
		private IHostingEnvironment _hostingEnvironment;
		string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";
		public InsertDev(IHostingEnvironment hostingEnvironment) {
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpPost]
		[Route("api/InsertNewDeveloper")]
		public List<Response> InsertDeveloper([FromBody]DevInsert data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("InsertNewDeveloper", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FirstName", data.DFirstName);
			cmd.Parameters.AddWithValue("@LastName", data.DLastName);
			cmd.Parameters.AddWithValue("@PhoneNumber", data.DPhoneNumber);
			cmd.Parameters.AddWithValue("@Email", data.DEmail);
			cmd.Parameters.AddWithValue("@Password", data.DPassword);
			cmd.Parameters.AddWithValue("@Description", data.DDescription);
			cmd.Parameters.AddWithValue("@PLanguages", data.DPLanguages);
			cmd.Parameters.AddWithValue("@Skills", data.DSkills);
			cmd.Parameters.AddWithValue("@Education", data.DEducation);
			cmd.Parameters.AddWithValue("@Certifications", data.DCertificates);
			cmd.Parameters.AddWithValue("@DesiredTitle", data.DTitle);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}


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
	}

}