using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class CustomerApproval 
	{
		public int CustomerPendingID { get; set; }
		public int CustomerID { get; set; }
		public int DeveloperID { get; set; }
		public string PriceOffered { get; set; }
		public string DateOffered { get; set; }
		public string Requirements { get; set; }
		public string OrderDesc { get; set; }
		public string Name { get; set; }

	}
}
