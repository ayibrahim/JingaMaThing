﻿using System;
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
namespace JMT.Controllers
{
    public class UserData : ControllerBase
    {
        //db dbop = new db();
        [HttpGet]
        [Route("api/userInfo")]
        public List<UserInfo> GetUser()
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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
                
            }
            return user;
        }

        [HttpGet]
        [Route("api/InserNewCustomer/{FirstName}/{LastName}/{PhoneNumber}/{Email}/{Password}")]
        public List<Response> InsertCustomer( string FirstName = "" , string LastName = "" , string PhoneNumber = "" , string Email = "" , string Password = "")
        {
            Response finalresult = new Response();
            List<Response> Customer = new List<Response>();
            string result = "Successful ";
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            //SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
            SqlConnection con = new SqlConnection(con2);
            SqlCommand cmd = new SqlCommand("InsertNewCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();
            finalresult.response = result.ToString();
            Customer.Add(finalresult);
            return Customer;
        }

        [HttpGet]
        [Route("api/InsertNewDeveloper/{FirstName}/{LastName}/{PhoneNumber}/{Email}/{Password}/{Description}/{PLanguages}/{Skills}/{Education}/{Certifications}/{DesiredTitle}")]
        public List<Response> InsertDeveloper(string FirstName = "", string LastName = "", string PhoneNumber = "", string Email = "", string Password = "" , string Description = "" , string PLanguages = "" , string Skills = "" , string Education = "" , string Certifications = ""
            , string DesiredTitle = "")
        {
            Response finalresult = new Response();
            List<Response> Developer = new List<Response>();
            string result = "Successful ";
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            //SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
            SqlConnection con = new SqlConnection(con2);
            SqlCommand cmd = new SqlCommand("InsertNewDeveloper", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@PLanguages", PLanguages);
            cmd.Parameters.AddWithValue("@Skills", Skills);
            cmd.Parameters.AddWithValue("@Education", Education);
            cmd.Parameters.AddWithValue("@Certifications", Certifications);
            cmd.Parameters.AddWithValue("@DesiredTitle", DesiredTitle);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();
            finalresult.response = result.ToString();
            Developer.Add(finalresult);
            return Developer;
        }


        [HttpGet]
        [Route("api/getCustomerInfo/{Email}/{Password}")]
        public List<CustomerInfo> GetCustomerInfo( string Email = "" , string Password = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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
                    customer.Add(finalcustomer);
                }

            }
            return customer;
        }
       

        [HttpGet]
        [Route("api/getDeveloperInfo/{Email}/{Password}")]
        public List<DeveloperInfo> GetDeveloperInfo(string Email = "", string Password = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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
                    customer.Add(finalcustomer);
                }

            }
            return customer;
        }
        [HttpGet]
        [Route("api/getCustomerInfoByID/{ID}")]
        public List<CustomerInfo> GetCustomerInfobyID(string ID = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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

            }
            return customer;
        }
        [HttpGet]
        [Route("api/getDeveloperInfoByID/{ID}")]
        public List<DeveloperInfo> GetDeveloperInfobyID(string ID = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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

            }
            return customer;
        }

        [HttpGet]
        [Route("api/UpdateCustomerInfo/{CustomerID}/{FirstName}/{LastName}/{PhoneNumber}/{Email}")]
        public string UpdateCustomerInfo(string CustomerID = "" , string FirstName = "" , string LastName = "" , string PhoneNumber = "" , string Email = "")
        {
            string response = "positive";
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("UpdateCustomerInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", Email);
                con.Open();
                cmd.ExecuteNonQuery();
                

            }
            return response;
        }

        [HttpGet]
        [Route("api/UpdateDeveloperInfo/{DeveloperID}/{FirstName}/{LastName}/{PhoneNumber}/{Email}/{Title}/{Skills}/{PLanguages}/{Education}/{Certificates}/{Description}")]
        public string UpdateDevInfo(string DeveloperID = "", string FirstName = "", string LastName = "", string PhoneNumber = "", string Email = "" , string Title = "" , string Skills = "" , string PLanguages = "" , string Education = "",
            string Certificates = "" , string Description = "")
        {
            string response = "positive";
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("UpdateDeveloperInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperID", DeveloperID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Skills", Skills);
                cmd.Parameters.AddWithValue("@PLanguages", PLanguages);
                cmd.Parameters.AddWithValue("@Education", Education);
                cmd.Parameters.AddWithValue("@Certificates", Certificates);
                cmd.Parameters.AddWithValue("@Description", Description);
                
                con.Open();
                cmd.ExecuteNonQuery();


            }
            return response;
        }

        [HttpGet]
        [Route("api/getDevGalleryInfo/{DeveloperID}")]
        public List<DevGalleryInfo> GetDevGalleyInfo(string DeveloperID = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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

            }
            return customer;
        }

        [HttpGet]
        [Route("api/getDevGalleryTable/{DeveloperID}")]
        public List<DevGalleryTable> GetDevGalleyTable(string DeveloperID = "")
        {
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
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
                    finalcustomer.Description = (rdr["Description"].ToString());
                    finalcustomer.Title = (rdr["Title"].ToString());
                    customer.Add(finalcustomer);
                }

            }
            return customer;
        }
        [HttpGet]
        [Route("api/UpdateDevGallery/{DeveloperProjectID}/{Description}/{Title}")]
        public string UpdateDevGallery(string DeveloperProjectID = "", string Description = "", string Title = "")
        {
            string response = "positive";
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("UpdateDevGalleryPhoto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperProjectID", DeveloperProjectID);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Title", Title);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return response;
        }

        [HttpGet]
        [Route("api/DeleteDevGallery/{DeveloperProjectID}")]
        public string DeleteDevGallery(string DeveloperProjectID = "")
        {
            string response = "positive";
            string con2 = "Server=DESKTOP-62GK3U2;Database=JMT;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(con2))
            {
                SqlCommand cmd = new SqlCommand("DeleteDevGalleryPhoto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperProjectID", DeveloperProjectID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return response;
        }
    }
   
}
