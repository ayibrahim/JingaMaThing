using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JMT.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JMT.Controllers {
	[Produces("application/json")]

	public class CustomerDashboard : Controller {
		string testing2 = "";
		private IHostingEnvironment _hostingEnvironment;
		string con2 = "Data Source = itd2.cincinnatistate.edu; Initial Catalog=CPDM-IbrahimA;User id=cpdm-ayibrahim;Password=0654407;";
		public CustomerDashboard(IHostingEnvironment hostingEnvironment) {
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpGet]
		[Route("api/GetDevListCustomerDashboard")]
		public List<DevListCustDashboard> GetDeveloperID() {
			
			List<DevListCustDashboard> customer = new List<DevListCustDashboard>();
			using (SqlConnection con = new SqlConnection(con2)) {
				SqlCommand cmd = new SqlCommand("GetDevList_CustomerDashboard", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					DevListCustDashboard finalcustomer = new DevListCustDashboard();
					finalcustomer.DeveloperID = (Convert.ToInt32(rdr["DeveloperID"]));
					finalcustomer.Name = (rdr["Name"].ToString());
					finalcustomer.Email = (rdr["Email"].ToString());
					finalcustomer.Photo = (rdr["Photo"].ToString());
					finalcustomer.PLanguages = (rdr["PLanguages"].ToString());
					customer.Add(finalcustomer);
				}
				con.Close();
			}
			return customer;
		}
	
	}

}