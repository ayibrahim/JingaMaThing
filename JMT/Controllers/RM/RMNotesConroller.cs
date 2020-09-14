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

	//Mark As Done
	public class RMNotesConroller : Controller {

		string con2 = "Server = DESKTOP-PBEU3TN;Database=JMT;Trusted_Connection=True";
		[HttpGet]
		[Route("api/CreateRMNote/{ResourceManagerID}/{Title}/{ViewType}")]
		public List<Response> CreateRMNote(string ResourceManagerID = "", string Title = "", string ViewType = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("CreateRMNote", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
			cmd.Parameters.AddWithValue("@Title", Title);
			cmd.Parameters.AddWithValue("@ViewType", ViewType);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/EditRMNoteTitleViewType/{ResourceManagerNotesID}/{Title}/{ViewType}")]
		public List<Response> EditRMNoteTitleViewType(string ResourceManagerNotesID = "", string Title = "", string ViewType = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateRMNote", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerNotesID", ResourceManagerNotesID);
			cmd.Parameters.AddWithValue("@Title", Title);
			cmd.Parameters.AddWithValue("@ViewType", ViewType);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}


		

		[HttpGet]
		[Route("api/GetRMNotes/{ResourceManagerID}")]
		public List<ResourceManagerNotes> GetRMNotes(string ResourceManagerID = "") {

			List<ResourceManagerNotes> devlist = new List<ResourceManagerNotes>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetRMNotes", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					ResourceManagerNotes finalcustomer = new ResourceManagerNotes();
					finalcustomer.ResourceManagerNotesID = Convert.ToInt32(rdr["ResourceManagerNotesID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.NoteContent = (rdr["NoteContent"].ToString());
					finalcustomer.ViewType = (rdr["ViewType"].ToString());
					devlist.Add(finalcustomer);
				}
				con.Close();
			}
			return devlist;
		}


		

		[HttpGet]
		[Route("api/DeleteRMNote/{ResourceManagerNotesID}")]
		public List<Response> DeleteRMNote(string ResourceManagerNotesID = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("DeleteRMNote", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerNotesID", ResourceManagerNotesID);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}


		
		[HttpPost]
		[Route("api/UpdateResourceManagerNote")]
		public List<Response> UpdateResourceManagerNote([FromBody]UpdateRMNote data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateResourceManagerNote", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerNotesID", data.ResourceManagerNotesID);
			cmd.Parameters.AddWithValue("@NoteContent", data.NoteContent);

			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}


		

		[HttpGet]
		[Route("api/GetPublicNotesRM/{ResourceManagerID}")]
		public List<PublicNotesDev> GetPublicNotesRM(string ResourceManagerID = "") {

			List<PublicNotesDev> customer = new List<PublicNotesDev>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetPublicNotes_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				cmd.Parameters.AddWithValue("@Selection", 1);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					PublicNotesDev finalcustomer = new PublicNotesDev();
					finalcustomer.NoteID = Convert.ToInt32(rdr["NoteID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.NoteContent = (rdr["NoteContent"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetPublicNotes_RM", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ResourceManagerID", ResourceManagerID);
				cmd.Parameters.AddWithValue("@Selection", 2);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read()) {
					PublicNotesDev finalcustomer = new PublicNotesDev();
					finalcustomer.NoteID = Convert.ToInt32(rdr["NoteID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.NoteContent = (rdr["NoteContent"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}

			return customer;
		}

	}

}