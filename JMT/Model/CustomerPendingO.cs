using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class CustomerPendingO {

		public int DeveloperPendingID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Budget { get; set; }
		public string Requirements { get; set; }
		public string Desired_Completion_Date { get; set; }
		public string DateCreated { get; set; }
	}

	public class CustomerPendingDeclined {

		public int DeveloperDeclinedID { get; set; }
		public string DeveloperName { get; set; }
		public string OrderDescription { get; set; }
		public string DeclineReason { get; set; }
		public string DeclinedDate { get; set; }
	
	}
}
