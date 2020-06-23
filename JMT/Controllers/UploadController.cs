using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JMT.Controllers
{
  
        [Produces("application/json")]
        
        public class UploadController : Controller
        {
            private IHostingEnvironment _hostingEnvironment;

            public UploadController(IHostingEnvironment hostingEnvironment)
            {
                _hostingEnvironment = hostingEnvironment;
            }

            [HttpPost, DisableRequestSizeLimit]
            [Route("api/Upload/{Email}/{Role}")]
         public ActionResult UploadFile( string Email = "" , string Role = "")
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
                    string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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
               
                return Json(test);
                }
                catch (System.Exception ex)
                {
                    return Json("Upload Failed: " + ex.Message);
                }
            }

        [HttpGet]
        [Route("api/GetProfileImageCustomer/{Email}")]
        public String GetCustImage(string Email = "")
        {
            object result = "";
            string finalresult = "";
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(con2);
            SqlCommand cmd = new SqlCommand("SELECT Photo From TCustomers Where Email = '"+Email+"'", con);
            con.Open();
            result = cmd.ExecuteScalar();
            finalresult = result.ToString();

            return finalresult;
        }

        [HttpGet]
        [Route("api/GetProfileImageDeveloper/{Email}")]
        public String GetDevImage(string Email = "")
        {
            object result = "";
            string finalresult = "";
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(con2);
            SqlCommand cmd = new SqlCommand("SELECT Photo From TDevelopers Where Email = '" + Email + "'", con);
            con.Open();
            result = cmd.ExecuteScalar();
            finalresult = result.ToString();
      
            return finalresult;
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("api/UploadDevGallery/{Email}/{Description}/{Title}")]
        public ActionResult UploadFile(string Email = "" , string Description = "" , string Title = "")
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
                    string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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
