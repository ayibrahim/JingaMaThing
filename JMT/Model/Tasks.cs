using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class Tasks 
	{
		public int DeveloperTaskID { get; set; }
		public int OrderNumber { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Notes { get; set; }
		public string Status { get; set; }
	}
}
