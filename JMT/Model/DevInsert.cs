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
}
