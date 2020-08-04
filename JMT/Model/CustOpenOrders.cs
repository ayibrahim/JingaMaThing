using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class CustOpenOrders 
	{
		public int OrderNumber { get; set; }
		public int CustomerID { get; set; }
		public string DeveloperName { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string CompletionDate { get; set; }
		public string Status { get; set; }
	}

	public class CustOrderHistory 
	{
		public int OrderNumber { get; set; }
		public string DeveloperName { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
		public string CompletionDate { get; set; }
	    public string Rating { get; set; }
		public string CustomerReview { get; set; }
	}
}
