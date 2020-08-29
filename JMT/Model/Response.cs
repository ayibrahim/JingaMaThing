using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model
{
    public class Response
    {
        public string response { get; set; }
    }

	public class DevCustomerApproved {
		public string CustomerPendingID { get; set; }
		public string CustomerID { get; set; }
		public string DeveloperID { get; set; }
		public string Price { get; set; }
		public string CompletionDate { get; set; }
		public string OrderDesc { get; set; }
		public string Requirements { get; set; }
		
	}

	public class InsertNewOrderCust {
		public string CustomerID { get; set; }
		public string DevEmail { get; set; }
		public string OrderDesc { get; set; }
		public string OrderRequirments { get; set; }
		public string Budget { get; set; }
		public string DateBy { get; set; }

	}
}
