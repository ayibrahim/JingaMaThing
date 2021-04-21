using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TDeveloperNotes
    {
        [Column("DeveloperNoteID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DeveloperNoteID { get; set; }

        [Column("DeveloperID")]
        [Required]
        public int DeveloperID { get; set; }

        [Column("Title")]
        [StringLength(1073741791)]
        public string Title { get; set; }

        [Column("NoteContent")]
        [StringLength(1073741791)]
        public string NoteContent { get; set; }

        [Column("ViewType")]
        [StringLength(1073741791)]
        public string ViewType { get; set; }

    }
}
