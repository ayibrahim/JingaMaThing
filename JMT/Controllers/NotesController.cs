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
	
	
	public class NotesController : Controller {
		string testing2 = "";
		private IHostingEnvironment _hostingEnvironment;
		string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";
		public NotesController(IHostingEnvironment hostingEnvironment) {
			_hostingEnvironment = hostingEnvironment;
		}

		

		[HttpGet]
		[Route("api/CreateDevNote/{DeveloperID}/{Title}/{ViewType}")]
		public List<Response> InsertNewTask(string DeveloperID = "" , string Title = "", string ViewType = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("CreateDevNote", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
			cmd.Parameters.AddWithValue("@Title", Title);
			cmd.Parameters.AddWithValue("@ViewType", ViewType);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}



		//[HttpPost]
		//[Route("api/UpdateTask")]
		//public List<Response> UpdateTask([FromBody]UpdateTask data) {
		//	Response finalresult = new Response();
		//	List<Response> Customer = new List<Response>();
		//	string result = "Successful ";
		//	//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
		//	SqlConnection con = new SqlConnection(con2);
		//	SqlCommand cmd = new SqlCommand("UpdateTask", con);
		//	cmd.CommandType = CommandType.StoredProcedure;
		//	cmd.Parameters.AddWithValue("@DeveloperTaskID", data.DeveloperTaskID);
		//	cmd.Parameters.AddWithValue("@Title", data.Title);
		//	cmd.Parameters.AddWithValue("@Description", data.Description);
		//	cmd.Parameters.AddWithValue("@Notes", data.Notes);
		//	cmd.Parameters.AddWithValue("@Status", data.Status);
		//	con.Open();
		//	int i = cmd.ExecuteNonQuery();
		//	con.Close();
		//	finalresult.response = result.ToString();
		//	Customer.Add(finalresult);
		//	return Customer;
		//}

	}

}