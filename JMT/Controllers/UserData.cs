using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;
using JMT.Exceptions;
using JMT.Model;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace JMT.Controllers
{
    public class UserData : ControllerBase
    {
		string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";
		//db dbop = new db();
		[HttpGet]
        [Route("api/userInfo")]
        public List<UserInfo> GetUser()
        {
            List<UserInfo> user = new List<UserInfo>();
            using (SqlConnection con = new SqlConnection(con2)) 
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TUsers", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) 
                {
                    UserInfo finaluser = new UserInfo();
                    finaluser.UserID = (Convert.ToInt32(rdr["UserID"]));
                    finaluser.FirstName = (rdr["FirstName"].ToString());
                    finaluser.LastName = (rdr["LastName"].ToString());
                    user.Add(finaluser);
                }
				con.Close();
			}
            return user;
        }


		[HttpPost]
		[Route("api/InserNewCustomer")]
		public List<Response> InsertDeveloper([FromBody]CustInsert data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("InsertNewCustomer", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FirstName", data.FirstName);
			cmd.Parameters.AddWithValue("@LastName", data.LastName);
			cmd.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
			cmd.Parameters.AddWithValue("@Email", data.Email);
			cmd.Parameters.AddWithValue("@Password", data.Password);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}


		[HttpGet]
        [Route("api/getCustomerInfo/{Email}/{Password}")]
        public List<CustomerInfo> GetCustomerInfo( string Email = "" , string Password = "")
        {
            List<CustomerInfo> customer = new List<CustomerInfo>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetCustomerInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustomerInfo finalcustomer = new CustomerInfo();
                    finalcustomer.CustomerID = (Convert.ToInt32(rdr["CustomerID"]));
                    finalcustomer.FirstName = (rdr["FirstName"].ToString());
                    finalcustomer.LastName = (rdr["LastName"].ToString());
                    finalcustomer.PhoneNumber = (rdr["PhoneNumber"].ToString());
                    finalcustomer.Email = (rdr["Email"].ToString());
                    finalcustomer.Password = (rdr["Password"].ToString());
                    finalcustomer.RoleDesc = (rdr["RoleDesc"].ToString());
                    finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.SideBarColor = (rdr["SideBarColor"].ToString());
					finalcustomer.DashboardColor = (rdr["DashboardColor"].ToString());
					customer.Add(finalcustomer);
                }
				con.Close();
			}
            return customer;
        }

		[HttpGet]
		[Route("api/GetResourceManagerInfo/{Email}/{Password}")]
		public List<RMInfo> GetResourceManagerInfo(string Email = "", string Password = "") {
			List<RMInfo> customer = new List<RMInfo>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetResourceManagerInfo", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Email", Email);
				cmd.Parameters.AddWithValue("@Password", Password);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					RMInfo finalcustomer = new RMInfo();
					finalcustomer.ResourceManagerID = (Convert.ToInt32(rdr["ResourceManagerID"]));
					finalcustomer.FirstName = (rdr["FirstName"].ToString());
					finalcustomer.LastName = (rdr["LastName"].ToString());
					finalcustomer.PhoneNumber = (rdr["PhoneNumber"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Password = (rdr["Password"].ToString());
					finalcustomer.RoleDesc = (rdr["RoleDesc"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.SideBarColor = (rdr["SideBarColor"].ToString());
					finalcustomer.DashboardColor = (rdr["DashboardColor"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}

		[HttpGet]
		[Route("api/GetResourceManagerInfoByID/{ID}")]
		public List<RMInfo> GetResourceManagerInfoByID(string ID = "") {
			List<RMInfo> customer = new List<RMInfo>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetResourceManagerInfoByID", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ID", ID);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					RMInfo finalcustomer = new RMInfo();
					finalcustomer.ResourceManagerID = (Convert.ToInt32(rdr["ResourceManagerID"]));
					finalcustomer.FirstName = (rdr["FirstName"].ToString());
					finalcustomer.LastName = (rdr["LastName"].ToString());
					finalcustomer.PhoneNumber = (rdr["PhoneNumber"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Password = (rdr["Password"].ToString());
					finalcustomer.RoleDesc = (rdr["RoleDesc"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}
		[HttpGet]
        [Route("api/getDeveloperInfo/{Email}/{Password}")]
        public List<DeveloperInfo> GetDeveloperInfo(string Email = "", string Password = "")
        {
            List<DeveloperInfo> customer = new List<DeveloperInfo>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetDeveloperInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DeveloperInfo finalcustomer = new DeveloperInfo();
                    finalcustomer.DeveloperID = (Convert.ToInt32(rdr["DeveloperID"]));
                    finalcustomer.FirstName = (rdr["FirstName"].ToString());
                    finalcustomer.LastName = (rdr["LastName"].ToString());
                    finalcustomer.PhoneNumber = (rdr["PhoneNumber"].ToString());
                    finalcustomer.Email = (rdr["Email"].ToString());
                    finalcustomer.Password = (rdr["Password"].ToString());
                    finalcustomer.Description = (rdr["Description"].ToString());
                    finalcustomer.PLanguages = (rdr["PLanguages"].ToString());
                    finalcustomer.Skills = (rdr["Skills"].ToString());
                    finalcustomer.Education = (rdr["Education"].ToString());
                    finalcustomer.Certification = (rdr["Certification"].ToString());
                    finalcustomer.Title = (rdr["Title"].ToString());
                    finalcustomer.RoleDesc = (rdr["RoleDesc"].ToString());
                    finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.SideBarColor = (rdr["SideBarColor"].ToString());
					finalcustomer.DashboardColor = (rdr["DashboardColor"].ToString());
					customer.Add(finalcustomer);
                }
				con.Close();
			}
            return customer;
        }
        [HttpGet]
        [Route("api/getCustomerInfoByID/{ID}")]
        public List<CustomerInfo> GetCustomerInfobyID(string ID = "")
        {
            List<CustomerInfo> customer = new List<CustomerInfo>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetCustomerInfoByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustomerInfo finalcustomer = new CustomerInfo();
                    finalcustomer.CustomerID = (Convert.ToInt32(rdr["CustomerID"]));
                    finalcustomer.FirstName = (rdr["FirstName"].ToString());
                    finalcustomer.LastName = (rdr["LastName"].ToString());
                    finalcustomer.PhoneNumber = (rdr["PhoneNumber"].ToString());
                    finalcustomer.Email = (rdr["Email"].ToString());
                    finalcustomer.Password = (rdr["Password"].ToString());
                    finalcustomer.RoleDesc = (rdr["RoleDesc"].ToString());
                    finalcustomer.Photo = (rdr["Photo"].ToString());
                    customer.Add(finalcustomer);
                }
				con.Close();
			}
            return customer;
        }
        [HttpGet]
        [Route("api/getDeveloperInfoByID/{ID}")]
        public List<DeveloperInfo> GetDeveloperInfobyID(string ID = "")
        {
            List<DeveloperInfo> customer = new List<DeveloperInfo>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetDeveloperInfoByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DeveloperInfo finalcustomer = new DeveloperInfo();
                    finalcustomer.DeveloperID = (Convert.ToInt32(rdr["DeveloperID"]));
                    finalcustomer.FirstName = (rdr["FirstName"].ToString());
                    finalcustomer.LastName = (rdr["LastName"].ToString());
                    finalcustomer.PhoneNumber = (rdr["PhoneNumber"].ToString());
                    finalcustomer.Email = (rdr["Email"].ToString());
                    finalcustomer.Password = (rdr["Password"].ToString());
                    finalcustomer.Description = (rdr["Description"].ToString());
                    finalcustomer.PLanguages = (rdr["PLanguages"].ToString());
                    finalcustomer.Skills = (rdr["Skills"].ToString());
                    finalcustomer.Education = (rdr["Education"].ToString());
                    finalcustomer.Certification = (rdr["Certification"].ToString());
                    finalcustomer.Title = (rdr["Title"].ToString());
                    finalcustomer.RoleDesc = (rdr["RoleDesc"].ToString());
                    finalcustomer.Photo = (rdr["Photo"].ToString());
                    customer.Add(finalcustomer);
                }
				con.Close();
			}
            return customer;
        }

       
		[HttpPost]
		[Route("api/UpdateCustomerInfo")]
		public List<Response> UpdateCustomerInfo([FromBody]CustUpdate data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateCustomerInfo", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CustomerID", data.CustomerID);
			cmd.Parameters.AddWithValue("@FirstName", data.FirstName);
			cmd.Parameters.AddWithValue("@LastName", data.LastName);
			cmd.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
			cmd.Parameters.AddWithValue("@Email", data.Email);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

		[HttpPost]
		[Route("api/UpdateRMInfo")]
		public List<Response> UpdateRMInfo([FromBody]RMUpdate data) {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			SqlConnection con = new SqlConnection(con2);
			SqlCommand cmd = new SqlCommand("UpdateRMInfo", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ResourceManagerID", data.ResourceManagerID);
			cmd.Parameters.AddWithValue("@FirstName", data.FirstName);
			cmd.Parameters.AddWithValue("@LastName", data.LastName);
			cmd.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
			cmd.Parameters.AddWithValue("@Email", data.Email);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}


		[HttpPost]
        [Route("api/UpdateDeveloperInfo")]
        public List<Response> UpdateDevInfo([FromBody]DevUpdate data)
        {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("UpdateDeveloperInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperID", data.DeveloperID);
                cmd.Parameters.AddWithValue("@FirstName", data.FirstName);
                cmd.Parameters.AddWithValue("@LastName", data.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", data.Email);
                cmd.Parameters.AddWithValue("@Title", data.Title);
                cmd.Parameters.AddWithValue("@Skills", data.Skills);
                cmd.Parameters.AddWithValue("@PLanguages", data.PLanguages);
                cmd.Parameters.AddWithValue("@Education", data.Education);
                cmd.Parameters.AddWithValue("@Certificates", data.Certificates);
                cmd.Parameters.AddWithValue("@Description", data.Description);
                
                con.Open();
                cmd.ExecuteNonQuery();

				con.Close();
			}
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

        [HttpGet]
        [Route("api/getDevGalleryInfo/{DeveloperID}")]
        public List<DevGalleryInfo> GetDevGalleyInfo(string DeveloperID = "")
        {
            List<DevGalleryInfo> customer = new List<DevGalleryInfo>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetDevGalleryInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DevGalleryInfo finalcustomer = new DevGalleryInfo();
                    finalcustomer.DeveloperID = (Convert.ToInt32(rdr["DeveloperID"]));
                    finalcustomer.PreviewImageSrc = (rdr["PreviewImageSrc"].ToString());
                    finalcustomer.ThumbnailImageSrc = (rdr["ThumbnailImageSrc"].ToString());
                    finalcustomer.Alt = (rdr["Alt"].ToString());
                    finalcustomer.Title = (rdr["Title"].ToString());
                    customer.Add(finalcustomer);
                }
				con.Close();
			}
            return customer;
        }

        [HttpGet]
        [Route("api/getDevGalleryTable/{DeveloperID}")]
        public List<DevGalleryTable> GetDevGalleyTable(string DeveloperID = "")
        {
            List<DevGalleryTable> customer = new List<DevGalleryTable>();
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("GetDevGalleryTable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DevGalleryTable finalcustomer = new DevGalleryTable();
                    finalcustomer.ImageID = (Convert.ToInt32(rdr["ImageID"]));
					finalcustomer.Title = (rdr["Title"].ToString());
					finalcustomer.Description = (rdr["Description"].ToString());
					finalcustomer.imagesrc = (rdr["imagesrc"].ToString());
					customer.Add(finalcustomer);
                }
				con.Close();
			}
            return customer;
        }
        [HttpGet]
        [Route("api/UpdateDevGallery/{DeveloperProjectID}/{Description}/{Title}")]
        public List<Response> UpdateDevGallery(string DeveloperProjectID = "", string Description = "", string Title = "")
        {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("UpdateDevGalleryPhoto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperProjectID", DeveloperProjectID);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Title", Title);
                con.Open();
                cmd.ExecuteNonQuery();
				con.Close();
			}
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

        [HttpGet]
        [Route("api/DeleteDevGallery/{DeveloperProjectID}")]
        public List<Response> DeleteDevGallery(string DeveloperProjectID = "")
        {
			Response finalresult = new Response();
			List<Response> Customer = new List<Response>();
			string result = "Successful ";
			using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("DeleteDevGalleryPhoto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperProjectID", DeveloperProjectID);

                con.Open();
                cmd.ExecuteNonQuery();
				con.Close();
			}
			finalresult.response = result.ToString();
			Customer.Add(finalresult);
			return Customer;
		}

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
	}
   
}
