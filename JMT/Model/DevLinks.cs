using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class DevLinks 
	{
		public string DeveloperLinkID { get; set; }
		public string Title { get; set; }
		public string HyperLink { get; set; }
		public string ViewType { get; set; }

	}

	public class RMLinks {
		public string ResourceManagerLinkID { get; set; }
		public string Title { get; set; }
		public string HyperLink { get; set; }
		public string ViewType { get; set; }

	}

	public class DevLinksData {
		public int DeveloperLinkID { get; set; }
		public string Title { get; set; }
		public string HyperLink { get; set; }
		public string ViewType { get; set; }

	}
	public class PublicDevLinks {
		public int LinkID { get; set; }
		public string Title { get; set; }
		public string HyperLink { get; set; }
		public string Role { get; set; }

	}
	public class CreateDevLink {
		public string DeveloperID { get; set; }
		public string LinkTitle { get; set; }
		public string LinkURL { get; set; }
		public string LinkType { get; set; }

	}

	public class CreateRMLink {
		public string ResourceManagerID { get; set; }
		public string LinkTitle { get; set; }
		public string LinkURL { get; set; }
		public string LinkType { get; set; }

	}

	public class RMLinkData {
		public int ResourceManagerLinkID { get; set; }
		public string Title { get; set; }
		public string HyperLink { get; set; }
		public string ViewType { get; set; }

	}

}
