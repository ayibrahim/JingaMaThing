using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TDeveloperLinks
    {
        [Column("DeveloperLinkID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DeveloperLinkID { get; set; }

        [Column("DeveloperID")]
        [Required]
        public int DeveloperID { get; set; }

        [Column("HyperLink")]
        [StringLength(1073741791)]
        [Required]
        public string HyperLink { get; set; }

        [Column("Title")]
        [StringLength(1073741791)]
        [Required]
        public string Title { get; set; }

        [Column("ViewType")]
        [StringLength(1073741791)]
        [Required]
        public string ViewType { get; set; }

       
    }
}
