﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class DevRMList 
	{
		public string Name { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }
		public string Photo { get; set; }
	}

	public class DevNotAssignedToRM {
		public int DeveloperID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Photo { get; set; }

		public string PLanguages { get; set; }
	}
}
