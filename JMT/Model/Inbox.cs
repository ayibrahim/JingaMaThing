using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model
{
    public class Inbox
    {
		public int ID { get; set; }
        public string Name { get; set; }
		public string Email { get; set; }
		public string RecievedDate { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
        

       

		
    }

	public class PasswordFromEmail {
		public string Password { get; set; }

	}
	public class InboxSent {
		public string ID { get; set; }
		public string Name { get; set; }
		public string SentDate { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		
		
	}
}
