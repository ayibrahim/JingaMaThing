using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class DevOpenOrder
	{
		public int OrderNumber { get; set; }
		public int DeveloperID { get; set; }
		public string CustomerName { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string CompletionDate { get; set; }
		public string Status { get; set; }

	}

	public class RMDevOpenOrder {
		public int OrderNumber { get; set; }
		public int CustomerID { get; set; }
		public int DeveloperID { get; set; }
		public string DeveloperName { get; set; }
		public string CustomerName { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string CompletionDate { get; set; }
		public string Price { get; set; }
		public string Status { get; set; }

	}
	
	public class DevOrderHistory {
		public int OrderNumber { get; set; }
		public string CustomerName { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string CompletionDate { get; set; }
		public string Rating { get; set; }
		public string CustomerReview { get; set; }
	}

	public class DevHistoryCustomerReview {
		public int OrderNumber { get; set; }
		public string Rating { get; set; }
		public string CustomerReview { get; set; }
	}
}
