using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JMT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers
{
    public class DeveloperInfoController : Controller
    {
        string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";

        [HttpPost]
        [Route("api/InsertNewDeveloper")]
        public List<Response> InsertDeveloper([FromBody] DevInsert data)
        {
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
        [Route("api/UpdateDeveloperInfo")]
        public List<Response> UpdateDevInfo([FromBody] DevUpdate data)
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
        [Route("api/GetProfileImageDeveloper/{Email}")]
        public String GetDevImage(string Email = "")
        {
            object result = "";
            string finalresult = "";

            SqlConnection con = new SqlConnection(con2);
            SqlCommand cmd = new SqlCommand("SELECT Photo From TDevelopers Where Email = '" + Email + "'", con);
            con.Open();
            result = cmd.ExecuteScalar();
            finalresult = result.ToString();
            con.Close();
            return finalresult;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("api/UploadDevGallery/{Email}/{Description}/{Title}")]
        public ActionResult UploadFile(string Email = "", string Description = "", string Title = "")
        {
            try
            {
                string test = "";
                var file = Request.Form.Files[0];
                string folderName = "Profile";
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

                    SqlConnection con = new SqlConnection(con2);
                    SqlCommand cmd = new SqlCommand("InsertDevGalleryPhoto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@NewPhoto", "https://localhost:44380/MyStaticFiles/Profile/" + Email + "/" + fileName);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return Json(test);
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
        }
    }
}
