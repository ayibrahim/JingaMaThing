using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JMT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers.Developer
{
    public class DeveloperNotesController : Controller
    {
        string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";

		[HttpGet]
		[Route("api/CreateDevNote/{DeveloperID}/{Title}/{ViewType}")]
		public List<Response> InsertNewTask(string DeveloperID = "", string Title = "", string ViewType = "")
		{
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

		[HttpGet]
		[Route("api/EditDevNoteTitleViewType/{DeveloperNoteID}/{Title}/{ViewType}")]
		public List<Response> EditDevNoteTitleViewType(string DeveloperNoteID = "", string Title = "", string ViewType = "")
		{
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateDevNote", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperNoteID", DeveloperNoteID);
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
		[Route("api/GetDeveloperNotes/{DeveloperID}")]
		public List<DeveloperNotes> GetDeveloperNotes(string DeveloperID = "")
		{

			List<DeveloperNotes> devlist = new List<DeveloperNotes>();
			using (SqlConnection con = new SqlConnection(con2))
			{
				SqlCommand cmd = new SqlCommand("GetDeveloperNotes", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					DeveloperNotes finalcustomer = new DeveloperNotes();
					finalcustomer.DeveloperNoteID = Convert.ToInt32(rdr["DeveloperNoteID"]);
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
		[Route("api/DeleteDevNote/{DeveloperNoteID}")]
		public List<Response> DeleteDevNote(string DeveloperNoteID = "")
		{
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("DeleteDevNote", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperNoteID", DeveloperNoteID);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpPost]
		[Route("api/UpdateDeveloperNote")]
		public List<Response> UpdateDeveloperNote([FromBody] UpdateDevote data)
		{
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateDeveloperNote", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeveloperNoteID", data.DeveloperNoteID);
			cmd.Parameters.AddWithValue("@NoteContent", data.NoteContent);

			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/GetPublicNotesDev/{DeveloperID}")]
		public List<PublicNotesDev> GetDevRMCustomerList(string DeveloperID = "")
		{

			List<PublicNotesDev> customer = new List<PublicNotesDev>();
			using (SqlConnection con = new SqlConnection(con2))
			{
				SqlCommand cmd = new SqlCommand("GetPublicNotes_Dev", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				cmd.Parameters.AddWithValue("@Selection", 1);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					PublicNotesDev finalcustomer = new PublicNotesDev();
					finalcustomer.NoteID = Convert.ToInt32(rdr["NoteID"]);
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.NoteContent = (rdr["NoteContent"].ToString());
					finalcustomer.Role = (rdr["Role"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			using (SqlConnection con = new SqlConnection(con2))
			{
				SqlCommand cmd = new SqlCommand("GetPublicNotes_Dev", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
				cmd.Parameters.AddWithValue("@Selection", 2);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
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
