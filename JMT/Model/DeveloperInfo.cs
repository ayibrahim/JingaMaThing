using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model
{
    public class DeveloperInfo
    {
        public int DeveloperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string PLanguages { get; set; }
        public string Skills { get; set; }
        public string Education { get; set; }
        public string Certification { get; set; }
        public string Title { get; set; }
        public string RoleDesc { get; set; }
        public string Photo { get; set; }
		public string SideBarColor { get; set; }
		public string DashboardColor { get; set; }
	}
}
