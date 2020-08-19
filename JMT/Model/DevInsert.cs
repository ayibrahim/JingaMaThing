using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class DevInsert 
	{
		public string DFirstName { get; set; }
		public string DLastName { get; set; }
		public string DPhoneNumber { get; set; }
		public string DEmail { get; set; }
		public string DPassword { get; set; }
		public string DDescription { get; set; }
		public string DPLanguages { get; set; }
		public string DSkills { get; set; }
		public string DEducation { get; set; }
		public string DCertificates { get; set; }
		public string DTitle { get; set; }
	}
	public class InsertNewOrder {
		public string CustomerID { get; set; }
		public string DevEmail { get; set; }
		public string OrderDesc { get; set; }
		public string OrderRequirments { get; set; }
		public string Budget { get; set; }
		public string DateBy { get; set; }
		
	}
	public class DevUpdate {
		public string DeveloperID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Title { get; set; }
		public string Skills { get; set; }
		public string PLanguages { get; set; }
		public string Education { get; set; }
		public string Certificates { get; set; }
		public string Description { get; set; }

	}

	public class CustInsert {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		
	}

	public class CustUpdate {
		public string CustomerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

	}

	public class RMUpdate {
		public string ResourceManagerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

	}
	public class SendMessage {
		public string RoleDesc { get; set; }
		public string Email { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string EmailTo { get; set; }

	}

	public class ResetPassword {
		public string Email { get; set; }
		public string Password { get; set; }

	}
}
