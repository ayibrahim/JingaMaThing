using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class UpdateOrderComplete 
	{
		public string OrderID { get; set; }
		public string Review { get; set; }
		public string Rating { get; set; }
	}
	public class UpdateRMOrder {
		public string OrderNumber { get; set; }
		public string NewPrice { get; set; }
		public string DateBy { get; set; }
		public string Requirements { get; set; }
	}
	
}
