using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class DevPendingOrder {
		public int DeveloperPendingID { get; set; }
		public int CustomerID { get; set; }
		public int DeveloperID { get; set; }
		public string OrderDesc { get; set; }
		public string DateRequested { get; set; }
		public string Budget { get; set; }
		public string Requirements { get; set; }
		public string Name { get; set; }

	}
	public class DevPendingCustomerApproval {
		public int CustomerPendingID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string PriceOffered { get; set; }
		public string Requirements { get; set; }
		public string DateOffered { get; set; }
		public string DateAccepted { get; set; }

	}
}
