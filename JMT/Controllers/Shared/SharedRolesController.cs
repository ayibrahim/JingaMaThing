using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JMT.Exceptions;
using JMT.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers
{
	//Mark As Done
	public class SharedRolesController : ControllerBase
    {
		string con2 = "Server = DESKTOP-PBEU3TN;Database=JMT;Trusted_Connection=True";

		[HttpGet]
		[Route("api/CheckUserEmail/{Email}")]
		public List<Response> CheckEmailExist(string Email = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Found";
			string result2 = "NotFound";
			//SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("CheckEmailExist", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Email", Email);
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
		[Route("api/UpdateUserSideBarColor/{UserID}/{UserRoleDesc}/{SideBarColor}")]
		public List<Response> UpdateUserSideBarColor(string UserID = "", string UserRoleDesc = "", string SideBarColor = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("UpdateUserSideBarColor", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserID", UserID);
				cmd.Parameters.AddWithValue("@UserRoleDesc", UserRoleDesc);
				cmd.Parameters.AddWithValue("@SideBarColor", SideBarColor);
				con.Open();
				cmd.ExecuteNonQuery();

				con.Close();
			}
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpGet]
		[Route("api/UpdateUserDashboardColor/{UserID}/{UserRoleDesc}/{DashboardColor}")]
		public List<Response> UpdateUserDashboardColor(string UserID = "", string UserRoleDesc = "", string DashboardColor = "") {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("UpdateUserDashboardColor", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserID", UserID);
				cmd.Parameters.AddWithValue("@UserRoleDesc", UserRoleDesc);
				cmd.Parameters.AddWithValue("@DashboardColor", DashboardColor);
				con.Open();
				cmd.ExecuteNonQuery();

				con.Close();
			}
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpPost, DisableRequestSizeLimit]
		[Route("api/Upload/{Email}/{Role}")]
		public ActionResult UploadFile(string Email = "", string Role = "")
		{
			try
			{
				string test = "";
				var file = Request.Form.Files[0];
				string folderName = "Images";
				string AssetsFolderPath = @"C:\Users\aibrahi\Desktop\JMT\JMT\wwwroot\MyStaticFiles";
				string newPath = Path.Combine(AssetsFolderPath, folderName);
				string newPath2 = newPath + @"\" + Email;
				if (!Directory.Exists(newPath))
				{
					Directory.CreateDirectory(newPath);
				}
				if (!Directory.Exists(newPath2))
				{
					Directory.CreateDirectory(newPath2);
				}
				if (file.Length > 0)
				{
					string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					string fullPath = Path.Combine(newPath2, fileName);
					test = fullPath;
					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					string newval = "https://localhost:44380/MyStaticFiles/Images/" + Email + "/" + fileName;

					SqlConnection con = new SqlConnection(con2);
					SqlCommand cmd = new SqlCommand("UpdatePhoto", con);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Email", Email);
					cmd.Parameters.AddWithValue("@NewPhoto", newval);
					cmd.Parameters.AddWithValue("@Role", Role);
					con.Open();
					int i = cmd.ExecuteNonQuery();
					con.Close();
				}

				return Ok(test);
			}
			catch (Exception ex)
			{
				return BadRequest("Upload Failed: " + ex.Message);
			}
		}
	}
   
}
