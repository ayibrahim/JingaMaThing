using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class DevList 
	{
		public string Email { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }

	}

	public class RMDevPendingList {
		public int DeveloperPendingID { get; set; }
		public string DeveloperName { get; set; }
		public string CustomerName { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string Budget { get; set; }
		public string DateRequested { get; set; }
		public string CreatedDate { get; set; }


	}
	public class RMCustPendingList {
		public int CustomerPendingID { get; set; }
		public string DeveloperName { get; set; }
		public string CustomerName { get; set; }
		public string PriceOffered { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string DateOffered { get; set; }
		public string DevAcceptedDate { get; set; }


	}

	public class RMDevOrderHistory {
		public int OrderNumber { get; set; }
		public string DeveloperName { get; set; }
		public string CustomerName { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string CompletionDate { get; set; }
		public string Rating { get; set; }
		public string CustomerReview { get; set; }
	}
}
