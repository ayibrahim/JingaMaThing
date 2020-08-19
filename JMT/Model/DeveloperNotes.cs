using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Model {
	public class DeveloperNotes 
	{
		public int DeveloperNoteID { get; set; }
		public string Title { get; set; }
		public string NoteContent { get; set; }
		public string ViewType { get; set; }

	}
	public class UpdateDevote 
	{
		public string DeveloperNoteID { get; set; }
		public string NoteContent { get; set; }
	}

	public class ResourceManagerNotes {
		public int ResourceManagerNotesID { get; set; }
		public string Title { get; set; }
		public string NoteContent { get; set; }
		public string ViewType { get; set; }

	}
	public class UpdateRMNote {
		public string ResourceManagerNotesID { get; set; }
		public string NoteContent { get; set; }
	}
}
